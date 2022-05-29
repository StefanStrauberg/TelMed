using AutoMapper;
using IdentityServer.GRPC;
using Referrals.Application.DTO.AnamnesisDtos;
using Referrals.Application.DTO.PurposeDtos;
using Referrals.Application.DTO.ReferralDtos;
using Referrals.Domain.AnamnesisEntity;
using Referrals.Domain.PurposeEntity;
using Referrals.Domain.ReferralEntity;

namespace Referrals.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Grpc AccountName to String
            CreateMap<AccName, string>()
                .ConstructUsing(src => src.Name.ToString());
            // Referral
            CreateMap<CreateReferralDto, Referral>();
            CreateMap<UpdateReferralDto, Referral>();
            CreateMap<Referral, ReferralDto>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId.ToString()));
            // Anamnesis
            CreateMap<AnamnesisDto, Anamnesis>();
            // Purpose
            CreateMap<PurposeDto, Purpose>();
        }
        
    }
}
