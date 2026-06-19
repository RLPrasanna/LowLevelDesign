using BookMyShow.Exceptions;
using BookMyShow.Model;
using BookMyShow.Model.Enums;
using BookMyShow.Repository;
using Microsoft.AspNetCore.Identity;

namespace BookMyShow.Service
{
    public class BookingService
    {
        private BookingRepository bookingRepository;
        private UserRepository userRepository;
        private ShowRepository showRepository;

        /*
         * This method will handle the booking process, including:
         * 1. Validating the input from database.
         * 2. Repository: get the details of a user using userId.
         * 3. get the details of show using showId.
         * 4. check whether the input seats are actually avaialble or not
         * 5. if they are available, mark them as blocked ---> TAKE A LOCK
         * 6. create a ticket object
         * 7. save that ticket object in the database. ---> RELEASE THE LOCK
         * 8. Return the booking object if created successfully.
         */
        public Booking CreateBooking(List<string> seatNumbers, long showId, long userId)
        {
            Show show = showRepository.GetById(showId);
            if (show == null)
            {
                throw new InvalidRequestException("ShowId is not correct! ");
            }

            User user = userRepository.GetById(userId);
            if (user == null)
            {
                throw new InvalidRequestException("UserId is not correct! ");
            }

            Booking booking = new Booking();
            booking.BookingStatus = BookingStatus.InProgress;
            booking.CreatedBy = user;
            booking.Show = show;
            booking.ShowSeats = null;

            bookingRepository.Add(booking);

            return booking;
        }
    }
}
