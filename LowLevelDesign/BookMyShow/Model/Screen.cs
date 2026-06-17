using BookMyShow.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShow.Model
{
    public class Screen : BaseModel
    {
        public string Name { get; set; }
        public List<Seat> Seats { get; set; }
        public List<Feature> Features { get; set; }
    }
}
