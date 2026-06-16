using BookMyShow.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShow.Model
{
    internal class Movie : BaseModel
    {
        public string Name { get; set; }
        public string Rating { get; set; }
        public List<Feature> Features { get; set; }
        public List<Actor> Actors { get; set; }
        public List<string> Languages { get; set; }
        public long Duration { get; set; }
    }
}
