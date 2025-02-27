using CashFlow.Communication.Requests;
using FluentValidation;
using CashFlow.Exceptions.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidator : AbstractValidator<RequestExpenseJson> // valida a requisição
    {
        public RegisterExpenseValidator(RequestExpenseJson request)
        {
            RuleFor(expense => expense.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_ERROR);
            RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.GREATER_THAN_ZERO);
            RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.DATE_LESS_OR_EQUAL_TO);
            RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage($"{ResourceErrorMessages.PAYMENT_ERROR} {request.PaymentType}");
        }
    }
}
