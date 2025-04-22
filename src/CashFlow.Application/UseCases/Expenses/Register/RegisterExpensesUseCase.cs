using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exceptions.ExceptionsBase;



namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpensesUseCase
    {
        RegisterExpensesUseCase()
        {

        }
        public ResponseRegisterExpanseJson Execute(RequestExpenseJson request)
        {
            Validate(request);



            return new ResponseRegisterExpanseJson()
            {
                Title = request.Title
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