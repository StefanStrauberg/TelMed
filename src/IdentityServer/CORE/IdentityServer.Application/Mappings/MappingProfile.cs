using AutoMapper;
using IdentityServer.Application.DTOs;
using IdentityServer.Domain;
using Organization.GRPC;
using Specialization.GRPC;

namespace IdentityServer.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Specialization GRPC
            CreateMap<List<string>, GetSpecIdsRequestList>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src));
            CreateMap<SpecName, string>()
                .ConstructUsing(src => src.Name.ToString());
            CreateMap<SpecNamesList, List<string>>()
                .ConvertUsing(src => src.Name.Select(name => name.ToString()).ToList());
            // Organization GRPC
            CreateMap<List<string>, GetOrgIdsRequestList>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src));
            CreateMap<OrgName, string>()
                .ConstructUsing(src => src.Name.ToString());
            CreateMap<OrgNamesList, List<string>>()
                .ConvertUsing(src => src.Name.Select(name => name.ToString()).ToList());
            // API
            CreateMap<AccountForRegistrationDto, ApplicationUser>();
            CreateMap<AccountForUpdateDto, ApplicationUser>();
            CreateMap<ApplicationRole, RoleDto>();
            CreateMap<ApplicationUser, AccountDto>().ReverseMap();
        }
    }
}
