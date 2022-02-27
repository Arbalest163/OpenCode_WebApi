namespace AccessControlService.Application.Users.Queries.GetUsers
{
    public class IdentifiersDto : IMapWith<IdentifiersUsers>
    {
        public byte[]? Photo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<IdentifiersUsers, IdentifiersDto>()
                .ForMember(x => x.Photo, opt => opt
                      .MapFrom(x => x.Photo))
                ;
        }
    }
}
