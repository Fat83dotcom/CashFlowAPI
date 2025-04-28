using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.Extensions.Configuration;

namespace CashFlow.Infraestructure.DataAccess.Repositories
{
    internal class ExpenseRepository : IExpenseRepository
    {
        private readonly IConfiguration _configuration;

        public ExpenseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Save(Expense expense)
        {
            using var context = new CashFlowDbContext(_configuration);

            context.Expenses.Add(expense);

            context.SaveChanges();
        }
    }
}
