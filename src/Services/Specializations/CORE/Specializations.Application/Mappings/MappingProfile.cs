using AutoMapper;
using Specializations.Application.DTO;
using Specializations.Domain;

namespace Specializations.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Specialization, UpdateSpecializationDto>().ReverseMap();
            CreateMap<Specialization, CreateSpecializationDto>().ReverseMap();
            CreateMap<Specialization, SpecializationDto>().ReverseMap();
        }
    }
}
