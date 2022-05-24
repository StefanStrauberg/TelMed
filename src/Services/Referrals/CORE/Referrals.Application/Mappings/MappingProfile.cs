using AutoMapper;
using IdentityServer.GRPC;
using Referrals.Application.DTO;
using Referrals.Domain;

namespace Referrals.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccName, string>()
                .ConstructUsing(src => src.Name.ToString());
            CreateMap<Referral, CreateReferralDto>().ReverseMap();
            CreateMap<Referral, UpdateReferralDto>().ReverseMap();
            CreateMap<Referral, ReferralDto>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId.ToString()));
        }
        
    }
}
