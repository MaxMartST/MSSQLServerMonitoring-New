using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSSQLServerMonitoring.Domain.UserModel;

namespace MSSQLServerMonitoring.Infrastructure.Data.UserModel.EntityConfigurations
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Email);
            builder.Property(x => x.Id).UseHiLo();
            builder.Property(x => x.Login).HasMaxLength(255).IsRequired();
        }
    }
}
