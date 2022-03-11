using AutoMapper;
using Organizations.Application.DTO;
using Organizations.Application.Features.Organization.Requests.Commands;
using Organizations.Domain;

namespace Organizations.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Organization, OrganizationDto>().ReverseMap();
            CreateMap<Organization, CreateOrganizationCommand>().ReverseMap();
            CreateMap<Organization, UpdateOrganizationCommand>().ReverseMap();
        }
    }
}
