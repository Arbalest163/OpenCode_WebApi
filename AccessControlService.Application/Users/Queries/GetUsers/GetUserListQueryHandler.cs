using AutoMapper.QueryableExtensions;

namespace AccessControlService.Application.Users.Queries.GetUsers
{
    public class GetUserListQueryHandler
        : IRequestHandler<GetUserListQuery, UserListVm>
    {
        private readonly IAccessControlDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IAccessControlDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserListVm> Handle(GetUserListQuery request,
            CancellationToken cancellationToken)
        {
            return string.IsNullOrWhiteSpace(request.Query) switch
            {
                false => new UserListVm
                { 
                    Users = await _dbContext.Users
                        .Include(i => i.IdentifiersUsers)
                        .Where(n => n.Name == request.Query)
                        .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
                },
                _ => new UserListVm
                {
                    Users = await _dbContext.Users
                        .Include(i => i.IdentifiersUsers)
                        .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
                }
            };
        }
    }
}
