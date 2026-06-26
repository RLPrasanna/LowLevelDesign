using Splitwise.Models;
using Splitwise.Models.Enum;
using System.Runtime.InteropServices;

namespace Splitwise.DTO
{
    public class CreateExpenseRequestDTO
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public long createdByUserId { get; set; }
        public List<long> UserExpenseIds { get; set; }
    }
}
