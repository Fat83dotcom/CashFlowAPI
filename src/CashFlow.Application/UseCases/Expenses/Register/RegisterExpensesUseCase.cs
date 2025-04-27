using CashFlow.Application.UseCases.Expenses.Register.Interfaces;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exceptions.ExceptionsBase;


namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpensesUseCase : IRegisterExpensesUseCase
    {
        private readonly IExpenseRepository _repository;

        public RegisterExpensesUseCase()
        {
        }

        public RegisterExpensesUseCase(IExpenseRepository respository)
        {
            _repository = respository;
        }

        public ResponseRegisterExpanseJson Execute(RequestExpenseJson request)
        {
            Validate(request);

            var entity = new Expense
            {
                Amount = request.Amount,
                Date = request.Date,
                Description = request.Description,
                Title = request.Title,
                PaymentType = (Domain.Enums.PaymentType)request.PaymentType
            };

            _repository.Save(entity);

            return new ResponseRegisterExpanseJson()
            {
                Id = entity.Id
            };
        }

        private void Validate(RequestExpenseJson request)
        {
            var validator = new RegisterExpenseValidator(request);
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(fv => fv.ErrorMessage).ToList(); // Extrai as mensagens de texto dos objetos validation failure
                throw new ErrorOnValidateException(errorMessages);
            }
        }
    }
}