using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Model
{
    internal class BaseModel
    {
        public long Id {  get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}
