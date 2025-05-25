using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.Extensions.Configuration;

namespace CashFlow.Infraestructure.DataAccess.Repositories
{
    internal class ExpenseRepository : IExpenseRepository
    {
        private readonly CashFlowDbContext _context;

        public ExpenseRepository(CashFlowDbContext context)
        {
            _context = context;
        }

        public void Save(Expense expense)
        {
            _context.Expenses.Add(expense);

            _context.SaveChanges();
        }
    }
}
