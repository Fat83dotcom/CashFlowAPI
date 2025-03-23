using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Enums;

namespace ValidatorsTests.Expenses.Register
{
    public class RegisterExpensesValidatorTests
    {
        [Fact]
        public void Success()
        {
            //Arrange
            RequestExpenseJson request = new()
            {
                Title = "Title",
                Description = "Description",
                Date = DateTime.Now,
                Amount = 1,
                PaymentType = PaymentType.Cash
            };
            RegisterExpenseValidator validator = new(request);
            
            //Act

            var result = validator.Validate(request);

            //Assert

            Assert.True(result.IsValid);
        }
    }
}
