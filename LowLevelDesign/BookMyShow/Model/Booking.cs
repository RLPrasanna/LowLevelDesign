using BookMyShow.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShow.Model
{
    internal class Booking : BaseModel
    {
        public BookingStatus BookingStatus { get; set; }
        public Show Show { get; set; }
        public User CreatedBy { get; set; }
        public List<ShowSeat> ShowSeats { get; set; }
        public Payment Payment { get; set; }
        public double TotalAmount { get; set; }
    }
}


