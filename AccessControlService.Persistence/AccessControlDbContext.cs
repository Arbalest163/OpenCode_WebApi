using AccessControlService.Application.Interfaces;
using AccessControlService.Domain;
using AccessControlService.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlService.Persistence
{
    public class AccessControlDbContext : DbContext, IAccessControlDbContext
    {
        public AccessControlDbContext(DbContextOptions<AccessControlDbContext> options) : base(options) { }
        public DbSet<User> Users => Set<User>();
        public DbSet<IdentifiersUsers> IdentifiersUsers => Set<IdentifiersUsers>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

