using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidator : AbstractValidator<RequestExpenseJson> // valida a requisição
    {
        public RegisterExpenseValidator(RequestExpenseJson request)
        {
            RuleFor(expense => expense.Title).NotEmpty().WithMessage("O titulo não pode estar vazio.");
            RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("O valor deve ser maior que zero.");
            RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data deve ser igual ou anterior a data atual.");
            RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage($"Tipo de pagamento invalido{request.PaymentType}");
        }
    }
}
