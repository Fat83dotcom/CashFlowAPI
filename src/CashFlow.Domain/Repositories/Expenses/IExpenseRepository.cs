using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpenseRepository
    {
        void Save(Expense expense);
    }
}
