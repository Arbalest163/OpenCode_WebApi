namespace AccessControlService.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public byte[]? Photo { get; set; }
        public IEnumerable<byte[]>? Identifiers { get; set; }
    }
}
