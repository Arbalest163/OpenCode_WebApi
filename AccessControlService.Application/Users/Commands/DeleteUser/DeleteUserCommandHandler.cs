namespace AccessControlService.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler
        : IRequestHandler<DeleteUserCommand>
    {
        private readonly IAccessControlDbContext _dbContext;
        public DeleteUserCommandHandler(IAccessControlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (user is null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
