using AutoMapper;
using Observations.Application.DTO;
using Observations.Domain;

namespace Observations.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Observation, CreateObservationDto>().ReverseMap();
            CreateMap<Observation, UpdateObservationDto>().ReverseMap();
            CreateMap<Observation, ObservationDto>().ReverseMap();
        }
    }
}
