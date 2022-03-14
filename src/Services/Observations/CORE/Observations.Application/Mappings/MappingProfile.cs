using AutoMapper;
using Observations.Application.Features.Observation.Requests.Commands;
using Observations.Domain;

namespace Observations.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Observation, CreateObservationCommand>().ReverseMap();
            CreateMap<Observation, UpdateObservationCommand>().ReverseMap();
        }
    }
}
