using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShow.Model
{
    internal class User : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
