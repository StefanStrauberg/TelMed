using AutoMapper;
using Referrals.Application.DTO;
using Referrals.Domain;

namespace Referrals.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Referral, CreateReferralDto>().ReverseMap();
            CreateMap<Referral, UpdateReferralDto>().ReverseMap();
            CreateMap<Referral, ReferralDto>().ReverseMap();
        }
        
    }
}
