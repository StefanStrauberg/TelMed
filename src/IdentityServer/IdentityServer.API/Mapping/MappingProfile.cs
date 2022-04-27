using AutoMapper;
using IdentityServer.API.Models;

namespace IdentityServer.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountForRegistrationDto, Account>();
            CreateMap<Account, AccountDto>();
        }
    }
}