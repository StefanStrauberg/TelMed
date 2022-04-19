using AutoMapper;
using Organizations.Application.DTO;
using Organizations.Domain;

namespace Organizations.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Organization, CreateOrganizationDto>().ReverseMap();
            CreateMap<Organization, UpdateOrganizationDto>().ReverseMap();
            CreateMap<Organization, OrganizationDto>().ReverseMap();
        }
    }
}
