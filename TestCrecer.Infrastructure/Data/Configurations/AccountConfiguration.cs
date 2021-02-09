using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestCrecer.Core.Entities;

namespace TestCrecer.Infrastructure.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("account");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User).WithOne(y => y.Account);
        }
    }
}