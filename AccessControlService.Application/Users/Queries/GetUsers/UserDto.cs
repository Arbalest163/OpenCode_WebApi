namespace AccessControlService.Application.Users.Queries.GetUsers
{
    public class UserDto : IMapWith<User>
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string? Patronymic { get; set; }
        public byte[] Photo { get; set; } = new byte[0];
        public List<IdentifiersDto>? Identifiers { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>()
                .ForMember(x=>x.Identifiers, opt => opt
                    .MapFrom(x => x.IdentifiersUsers))
                ;
        }
    }
}
