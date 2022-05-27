using AutoMapper;
using Purposes.Application.DTO;
using Purposes.Domain;

namespace Purposes.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Purpose, UpdatePurposeDto>().ReverseMap();
            CreateMap<Purpose, CreatePurposeDto>().ReverseMap();
            CreateMap<Purpose, PurposeDto>().ReverseMap();
        }
    }
}
