using AutoMapper;
using Referrals.Application.Features.Referral.Requests.Commands;
using Referrals.Domain;

namespace Referrals.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Referral, CreateReferralCommand>().ReverseMap();
            CreateMap<Referral, UpdateReferralCommand>().ReverseMap();
        }
    }
}
