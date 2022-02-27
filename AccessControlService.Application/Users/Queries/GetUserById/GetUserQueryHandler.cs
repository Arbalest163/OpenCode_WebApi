namespace AccessControlService.Application.Users.Queries.GetUserById
{
    public class GetUserQueryHandler
        : IRequestHandler<GetUserQuery, UserVm>
    {
        private readonly IAccessControlDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IAccessControlDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserVm> Handle(GetUserQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.Include(x=>x.IdentifiersUsers).FirstOrDefaultAsync(x => x.Id == request.Id);

            if (user is null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            return _mapper.Map<UserVm>(user);
        }
    }
}
