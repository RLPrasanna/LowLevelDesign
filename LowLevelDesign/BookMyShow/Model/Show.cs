using BookMyShow.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShow.Model
{
    internal class Show : BaseModel
    {
        public Movie Movie { get; set; }
        public DateTime StartTime { get; set; }
        public Screen Screen { get; set; }
        public List<Feature> Features { get; set; }
    }
}
