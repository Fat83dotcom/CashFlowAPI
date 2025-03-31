using Bogus;
using Bogus.DataSets;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestsUtilities
{
    public class RequestRegisterExpenseBuilder
    {
        public RequestExpenseJson Build()
        {
            RequestExpenseJsonFaker requestExpenseFaker = new();
            return requestExpenseFaker.Generate();   
        }
    }
}

public class RequestExpenseJsonFaker : Faker<RequestExpenseJson>
{
    public RequestExpenseJsonFaker()
    {
        RuleFor(r => r.Title, f => f.Name.JobTitle());
        RuleFor(r => r.Description, f => f.Rant.Review());
        RuleFor(r => r.Date, f => f.Date.Between(DateTime.Now.AddDays(-30), DateTime.Now));
        RuleFor(r => r.Amount, f => f.Random.Number(0, 5000));
        RuleFor(r => r.PaymentType, f => f.PickRandom<PaymentType>());
    }
}