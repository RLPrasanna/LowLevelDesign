using Microsoft.EntityFrameworkCore;
using Splitwise.Models;

namespace Splitwise
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<UserExpense> UserExpenses { get; set; }
    }
}
