using Microsoft.AspNetCore.Mvc;
using Splitwise.DTO;
using Splitwise.Models;
using Splitwise.Models.Enum;
using Splitwise.Service;

namespace Splitwise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SettleUpController : Controller
    {
        private readonly ISettleUpService settleUpService;

        public SettleUpController(ISettleUpService settleUpService)
        {
            this.settleUpService = settleUpService;
        }
        public SettleUpResponseDTO SettleUp(SettleUpRequestDTO requestDTO)
        {
            SettleUpResponseDTO responseDTO = null;
            try
            {
                List<Expense> expenses = this.settleUpService.SettleUpUser(requestDTO.userId);
                responseDTO = new SettleUpResponseDTO
                {
                    Expenses = expenses,
                    ResponseStatus = ResponseStatus.Success
                };
            }
            catch(Exception ex)
            {
                responseDTO.ResponseStatus = ResponseStatus.Failure;
            }
            return responseDTO;
        }
    }
}
