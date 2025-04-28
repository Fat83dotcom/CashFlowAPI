using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Application.UseCases.Expenses.Register.Interfaces
{
    public interface IRegisterExpensesUseCase
    {
        public ResponseRegisterExpanseJson Execute(RequestExpenseJson request);
    }
}
