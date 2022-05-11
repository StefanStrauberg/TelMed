using AutoMapper;
using IdentityServer.Application.DTOs;
using IdentityServer.Domain;

namespace IdentityServer.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountForRegistrationDto, ApplicationUser>();
            CreateMap<AccountForUpdateDto, ApplicationUser>();
            CreateMap<ApplicationRole, RoleDto>();
            CreateMap<ApplicationUser, AccountDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => string.Join(", ", src.Roles)));
        }
    }
}
