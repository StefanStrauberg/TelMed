using Anamnesies.Application.Features.Referral.Requests.Commands;
using Anamnesies.Domain;
using AutoMapper;

namespace Referrals.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Anamnesis, CreateAnamnesisCommand>().ReverseMap();
            CreateMap<Anamnesis, UpdateAnamnesisCommand>().ReverseMap();
        }
    }
}
