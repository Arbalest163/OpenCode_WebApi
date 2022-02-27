namespace AccessControlService.Application.Interfaces
{
    public interface IAccessControlDbContext
    {
        DbSet<User> Users { get; }
        DbSet<IdentifiersUsers> IdentifiersUsers { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
