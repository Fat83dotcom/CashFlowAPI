using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infraestructure.DataAccess;
using CashFlow.Infraestructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infraestructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) // Ao passar this é criado um metodo de extensão de Iservicecollection
        {
            AddDBcontext(services, configuration);
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
        }

        private static void AddDBcontext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("mySql");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 42));

            services.AddDbContext<CashFlowDbContext>(options =>
                options.UseMySql(connectionString, serverVersion));
        }
    }
}
