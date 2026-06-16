using BookMyShow.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShow.Model
{
    internal class Payment : BaseModel
    {
        public string ExternalId { get; set; }
        public double totalAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
