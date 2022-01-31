using AutoMapper;
using Infastructure.Entities;
using pixel_backend.DTO;

namespace pixel_backend.AutoMappers
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<File, FileDTO>()
                .ForMember(dest => dest.Src,
                           opts => opts.MapFrom(src => src.RegularImageUrl));
        }
    }
}
