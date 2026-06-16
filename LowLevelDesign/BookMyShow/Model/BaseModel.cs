using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShow.Model
{
    internal class BaseModel
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
