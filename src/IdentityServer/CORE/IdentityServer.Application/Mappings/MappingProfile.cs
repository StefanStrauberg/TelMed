using AutoMapper;
using IdentityServer.Application.DTOs;
using IdentityServer.Domain;

namespace IdentityServer.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountForRegistrationDto, Account>();
            CreateMap<AccountForUpdateDto, Account>();
            CreateMap<Account, AccountDto>();
        }
    }
}
