using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Enums;
using CommonTestsUtilities;
using FluentAssertions;
using CashFlow.Exceptions.ExceptionsBase;

namespace ValidatorsTests.Expenses.Register
{
    public class RegisterExpensesValidatorTests
    {
        [Fact]
        public void Success()
        {
            //Arrange
            RequestRegisterExpenseBuilder requestBuilder = new();
            var request = requestBuilder.Build();
            RegisterExpenseValidator validator = new(request);
            
            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void ErrorTitleEmpty()
        {
            //Arrange
            RequestRegisterExpenseBuilder requestBuilder = new();
            var request = requestBuilder.Build();
            RegisterExpenseValidator validator = new(request);
            request.Title = string.Empty;

            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_ERROR));
            // ContainSingle sem expressão lambda ferifica se a lista contem somente um elemento
            // Com a expressão, ele verifica se existe a ocorrencia, independente do tamanho da lista, somente uma vez.
        }

        [Theory] // Permite que a função de teste receba parametros
        [InlineData(0)] // Passa os parametros para a função
        [InlineData(-1)] // Passa os parametros para a função
        [InlineData(-2)] // Passa os parametros para a função
        public void ErrorAmountEqualZero(decimal amount)
        {
            //Arrange
            RequestRegisterExpenseBuilder requestBuilder = new();
            var request = requestBuilder.Build();
            RegisterExpenseValidator validator = new(request);
            request.Amount = amount;

            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.GREATER_THAN_ZERO));
        }

        [Fact]
        public void ErrorToFutureDate()
        {
            //Arrange
            RequestRegisterExpenseBuilder requestBuilder = new();
            var request = requestBuilder.Build();
            RegisterExpenseValidator validator = new(request);
            request.Date = DateTime.Now.AddDays(1);

            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.DATE_LESS_OR_EQUAL_TO));
        }

        [Fact]
        public void ErrorToPayment()
        {
            //Arrange
            RequestRegisterExpenseBuilder requestBuilder = new();
            var request = requestBuilder.Build();
            RegisterExpenseValidator validator = new(request);
            request.PaymentType = (PaymentType)15;

            //Act
            var result = validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_ERROR));
        }
    }
}
