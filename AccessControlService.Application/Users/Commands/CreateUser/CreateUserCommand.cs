namespace AccessControlService.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string? Patronymic { get; set; }
        public byte[] Photo { get; set; } = new byte[0];
        public IEnumerable<byte[]>? Identifiers { get; set; }
    }
}
