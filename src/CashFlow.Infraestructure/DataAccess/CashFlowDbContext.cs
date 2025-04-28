using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CashFlow.Infraestructure.DataAccess
{
    public class CashFlowDbContext : DbContext
    {
        private readonly string? _ConnectString;

        public DbSet<Expense> Expenses { get; set; }

        public CashFlowDbContext(IConfiguration configuration)
        {
            _ConnectString = configuration.GetConnectionString("mySql");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 42));

            if (_ConnectString is not null)
            {
                optionsBuilder.UseMySql(_ConnectString, serverVersion); 
            }
        }
    }
}
