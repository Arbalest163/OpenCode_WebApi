using AccessControlService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessControlService.Persistence.EntityTypeConfigurations
{
    public class IdentifiersUsersConfiguration : IEntityTypeConfiguration<IdentifiersUsers>
    {
        public void Configure(EntityTypeBuilder<IdentifiersUsers> builder)
        {
            
        }
    }
}
