using AutoMapper;
using Specializations.Application.DTO;
using Specializations.Application.Features.Specialization.Requests.Commands;
using Specializations.Domain;

namespace Specializations.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Specialization, SpecializationDto>().ReverseMap();
            CreateMap<Specialization, UpdateSpecializationCommand>().ReverseMap();
            CreateMap<Specialization, CreateSpecializationCommand>().ReverseMap();
        }
    }
}
