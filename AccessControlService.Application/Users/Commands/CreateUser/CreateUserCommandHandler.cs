namespace AccessControlService.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IAccessControlDbContext _dbContext;
        public CreateUserCommandHandler(IAccessControlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            
            List<IdentifiersUsers>? identifiers = null;
            if (request.Identifiers is not null)
            {
                identifiers = new();
                foreach (var photo in request.Identifiers)
                {
                    identifiers.Add(new IdentifiersUsers { Photo = photo });
                }
            }

            var user = new User
            {
                Name = request.Name,
                Surname = request.Surname,
                Patronymic = request.Patronymic,
                Photo = request.Photo,
                IdentifiersUsers = identifiers
            };
            
            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
