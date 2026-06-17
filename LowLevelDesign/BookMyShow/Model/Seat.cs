using BookMyShow.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShow.Model
{
    public class Seat : BaseModel
    {
        public string SeatNumber { get; set; }
        public int RowNo { get; set; }
        public int ColNo { get; set; }
        public SeatType SeatType { get; set; }
    }
}
