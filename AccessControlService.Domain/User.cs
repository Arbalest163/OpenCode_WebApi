namespace AccessControlService.Domain
{
    public class User : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string? Patronymic { get; set; }
        public byte[] Photo { get; set; } = new byte[0];
        public virtual List<IdentifiersUsers>? IdentifiersUsers { get; set; }
    }
}
