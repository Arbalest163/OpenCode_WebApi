namespace AccessControlService.Application.Users.Queries.GetUsers
{
    public class GetUserListQuery : IRequest<UserListVm>
    {
        public string? Query { get; set; }
    }
}
