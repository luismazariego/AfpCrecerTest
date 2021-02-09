using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TestCrecer.Core.Entities;

namespace TestCrecer.Infrastructure.Data
{
    public class TestCrecerContext : DbContext
    {
        public TestCrecerContext(DbContextOptions options) : base(options)
        {            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}