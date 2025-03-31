using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Enums;
using CommonTestsUtilities;
using FluentAssertions;

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
    }
}
