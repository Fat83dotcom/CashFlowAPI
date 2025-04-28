using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Application.UseCases.Expenses.Register.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application
{
    public static class DependecyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRegisterExpensesUseCase, RegisterExpensesUseCase>();
        }
    }
}
