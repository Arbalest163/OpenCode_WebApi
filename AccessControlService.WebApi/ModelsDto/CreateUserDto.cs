namespace AccessControlService.WebApi.ModelsDto
{
    public class CreateUserDto : IMapWith<CreateUserCommand>
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Surname { get; set; } = string.Empty;
        public string? Patronymic { get; set; }
        [Required]
        [CustomFileExtensions
            (FileExtensions = "jpg,jpeg,bmp,png",
             ErrorMessage = "Please select only Supported Files .png | .jpg | .jpeg | .bmp")]
        public IFormFile? Photo { get; set; }
        [CustomFileExtensions
            (FileExtensions = "jpg,jpeg,bmp,png",
             ErrorMessage = "Please select only Supported Files .png | .jpg | .jpeg | .bmp")]
        public IFormFileCollection? Identifiers { get; set; }
        
        public void Mapping(Profile profile)
        {
            var file = Photo;
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                .ForMember(p => p.Photo,
                    opt => opt.MapFrom(d => Converter.ConvertToBytes(d.Photo)))
                .ForMember(p => p.Identifiers,
                    opt => opt.MapFrom(d => Converter.ConvertToCollectionBytes(d.Identifiers)))
                ;
        }
    }
}
