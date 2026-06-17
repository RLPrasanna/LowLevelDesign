using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShow.Model
{
    public class Theatre : BaseModel
    {
        public string Name { get; set; }
        public City City { get; set; }
        public List<Screen> Screens { get; set; }
    }
}
