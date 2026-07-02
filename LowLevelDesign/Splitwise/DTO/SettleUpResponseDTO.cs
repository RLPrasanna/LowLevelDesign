using Splitwise.Models;
using Splitwise.Models.Enum;

namespace Splitwise.DTO
{
    public class SettleUpResponseDTO
    {
        public List<Expense> Expenses { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}
