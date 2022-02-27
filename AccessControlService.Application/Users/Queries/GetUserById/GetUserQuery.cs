namespace AccessControlService.Application.Users.Queries.GetUserById
{
    public class GetUserQuery : IRequest<UserVm>
    {
        public int Id { get; set; }
    }
}
