using AutoMapper;
using Organizations.Application.DTOs.Organization;
using Organizations.Domain;

namespace Organizations.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Organization, OrganizationDto>().ReverseMap();
            CreateMap<Organization, CreateOrganizationDto>().ReverseMap();
            CreateMap<Organization, UpdateOrganizationDto>().ReverseMap();
        }
    }
}
