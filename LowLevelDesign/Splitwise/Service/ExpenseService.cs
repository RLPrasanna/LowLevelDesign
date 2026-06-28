using Splitwise.Exceptions;
using Splitwise.Models;
using Splitwise.Models.Enum;
using Splitwise.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Splitwise.Service
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository expenseRepository;
        private readonly IUserRepository userRepository;
        private readonly IUserExpenseRepository userExpenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository, IUserRepository userRepository)
        {
            expenseRepository = expenseRepository;
            userRepository = userRepository;
            userExpenseRepository = userExpenseRepository;
        }
        public Expense CreateExpense(string description, double amount, long createdByUserId, List<long> userExpenseIds)
        {
            //validations
            User existingUser= userRepository.GetById(createdByUserId);
            if (IsInvalidRequest(existingUser))
            {
                throw new InvalidRequestException("Invalid request. Please check the input parameters.");
            }
            List<UserExpense> userExpenses = userExpenseRepository.GetAll().Where(u=>u.User.Id==createdByUserId).ToList();

            // Create the expense
            Expense expenseToBeCreated = new Expense();
            expenseToBeCreated.Description = description;
            expenseToBeCreated.Amount = amount;
            expenseToBeCreated.ExpenseCreatedBy = existingUser;
            expenseToBeCreated.UserExpenses = userExpenses;
            expenseToBeCreated.ExpenseType = ExpenseType.Normal;

            Expense createdExpense = expenseRepository.Add(expenseToBeCreated);
            Console.WriteLine("Expense is created successfully!" + createdExpense.Id);

            return createdExpense;
        }


        private bool IsInvalidRequest(User existingUser)
        {
            //Todo: Implement validation logic for the request
            return false;
        }
    }
}
