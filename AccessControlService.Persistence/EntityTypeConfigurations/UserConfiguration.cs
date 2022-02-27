using AccessControlService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessControlService.Persistence.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(n => n.Name).IsRequired();

            builder.Property(n => n.Surname).IsRequired();
            builder.Property(n => n.Photo).IsRequired();
        }
    }
}
