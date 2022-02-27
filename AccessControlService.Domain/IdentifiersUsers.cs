namespace AccessControlService.Domain
{
    public class IdentifiersUsers : Entity
    {
        public virtual User? User { get; set; }
        public byte[]? Photo { get; set; }
    }
}
