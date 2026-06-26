using Microsoft.AspNetCore.Mvc;
using Splitwise.DTO;
using Splitwise.Models;
using Splitwise.Service;

namespace Splitwise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost("")]
        public CreateExpenseResponseDTO CreateExpense(CreateExpenseRequestDTO request)
        {
            CreateExpenseResponseDTO responseDTO = new CreateExpenseResponseDTO();

            try
            {
                Expense createdExpense = _expenseService.CreateExpense(request.Description, request.Amount, request.createdByUserId, request.UserExpenseIds);
                responseDTO.ExpenseId = createdExpense.Id;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error creating expense: {ex.Message}");
                Response.StatusCode = 500; // Internal Server Error
                return null; // or return an error response DTO if there is one
            }
            return responseDTO;
        }

        //Todo: Implement other endpoints for ExpenseController (e.g., GetExpense, UpdateExpense, DeleteExpense).
    }
}
