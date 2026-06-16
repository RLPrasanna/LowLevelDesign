using BookMyShow.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShow.Model
{
    internal class ShowSeat : BaseModel
    {
        public Show Show { get; set; }
        public Seat Seat { get; set; }
        public ShowSeatStatus ShowSeatStatus { get; set; }
    }
}
