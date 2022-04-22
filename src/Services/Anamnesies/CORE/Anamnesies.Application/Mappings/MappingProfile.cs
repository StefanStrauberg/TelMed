using Anamnesies.Application.DTO;
using Anamnesies.Domain;
using AutoMapper;

namespace Referrals.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Anamnesis, CreateAnamnesisDto>().ReverseMap();
            CreateMap<Anamnesis, UpdateAnamnesisDto>().ReverseMap();
            CreateMap<Anamnesis, AnamnesisDto>().ReverseMap();
        }
    }
}
