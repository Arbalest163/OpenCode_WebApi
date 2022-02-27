namespace AccessControlService.WebApi.ModelsDto
{
    public class UpdateUserDto : IMapWith<UpdateUserCommand>
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
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
            profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
                .ForMember(p => p.Photo,
                    opt => opt.MapFrom(d => Converter.ConvertToBytes(d.Photo)))
                .ForMember(p => p.Identifiers,
                    opt => opt.MapFrom(d => Converter.ConvertToCollectionBytes(d.Identifiers)))
                ;
        }
    }
}
