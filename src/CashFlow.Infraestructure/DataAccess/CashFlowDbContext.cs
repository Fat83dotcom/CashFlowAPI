using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CashFlow.Infraestructure.DataAccess
{
    public class CashFlowDbContext : DbContext
    {

        public CashFlowDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Expense> Expenses { get; set; }

    }
}
