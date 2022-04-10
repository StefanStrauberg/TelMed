using AutoMapper;
using IdentityServer.API.DTOs;
using IdentityServer.Core.Entities;

namespace IdentityServer.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Account, AccountDto>();
        }
    }
}
