namespace AccessControlService.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler
        : IRequestHandler<UpdateUserCommand>
    {
        private readonly IAccessControlDbContext _dbContext;
        public UpdateUserCommandHandler(IAccessControlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                entity.Name = request.Name;
            }
            if (!string.IsNullOrWhiteSpace(request.Surname))
            {
                entity.Surname = request.Surname;
            }
            if (!string.IsNullOrWhiteSpace(request.Patronymic))
            {
                entity.Patronymic = request.Patronymic;
            }
            if (request.Photo is not null)
            {
                entity.Photo = request.Photo;
            }
            
            List<IdentifiersUsers>? identifiers = null;
            if (request.Identifiers is not null)
            {
                identifiers = new();
                foreach (var photo in request.Identifiers)
                {
                    identifiers.Add(new IdentifiersUsers { Photo = photo });
                }

                entity.IdentifiersUsers = identifiers;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
