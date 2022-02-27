using AccessControlService.Domain.Interfaces;

namespace AccessControlService.Domain
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
