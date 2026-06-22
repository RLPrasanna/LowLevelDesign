using BookMyShow.Exceptions;
using BookMyShow.Model;
using BookMyShow.Model.Enums;
using BookMyShow.Repository;
using BookMyShow.Data;

namespace BookMyShow.Service
{
    public class BookingService
    {
        private static readonly object bookingLock = new();
        private readonly AppDBContext dbContext;
        private readonly IBookingRepository bookingRepository;
        private readonly IUserReository userRepository;
        private readonly IShowRepository showRepository;
        private readonly IShowSeatRepository showSeatRepository;

        public BookingService(
            AppDBContext dbContext,
            IBookingRepository bookingRepository,
            IUserReository userRepository,
            IShowRepository showRepository,
            IShowSeatRepository showSeatRepository)
        {
            this.dbContext = dbContext;
            this.bookingRepository = bookingRepository;
            this.userRepository = userRepository;
            this.showRepository = showRepository;
            this.showSeatRepository = showSeatRepository;
        }

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
            using var transaction = dbContext.Database.BeginTransaction();
            try
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

                List<ShowSeat> lockedSeats;

                lock (bookingLock)
                {
                    List<ShowSeat> allShowSeats = showSeatRepository.GetByShowId(showId);
                    // [1,2,3,4,5,6,7,8,9,10]

                    foreach (var showseat in allShowSeats)
                    {
                        // [2,3,4]
                        if (seatNumbers.Contains(showseat.Seat.SeatNumber) && showseat.ShowSeatStatus != ShowSeatStatus.Available)
                        {
                            throw new SeatNotAvailableException("Seats are not available! " + showseat.Seat.SeatNumber);
                        }
                    }

                    Console.WriteLine("Fetched all show seats: " + allShowSeats.Count);

                    lockedSeats = [];

                    foreach (var showseat in allShowSeats)
                    {
                        if (seatNumbers.Contains(showseat.Seat.SeatNumber))
                        {
                            showseat.ShowSeatStatus = ShowSeatStatus.Locked;
                            showSeatRepository.Update(showseat);
                            lockedSeats.Add(showseat);
                        }
                    }

                    Booking booking = new Booking
                    {
                        BookingStatus = BookingStatus.InProgress,
                        CreatedBy = user,
                        Show = show,
                        ShowSeats = lockedSeats,
                        TotalAmount = calculateTotalAmount(lockedSeats),
                        Payment = null //Todo: Create Payment object and add it here
                    };

                    bookingRepository.Add(booking);

                    transaction.Commit();

                    return booking;
                }
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private double calculateTotalAmount(List<ShowSeat> lockedSeats)
        {
            double totalAmount = 0;
            var seatTypePrices = showSeatRepository.GetSeatTypePrices(lockedSeats.Select(x => x.Seat.SeatType).ToList());

            foreach (var seatTypePrice in seatTypePrices)
            {
                totalAmount += seatTypePrice.Value * lockedSeats.Count(x => x.Seat.SeatType == seatTypePrice.Key);
            }

            return totalAmount;
        }
    }
}
