using AutoMapper;
using Organizations.Application.DTO;
using Organizations.Domain;

namespace Organizations.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOrganizationDto, Organization>();
            CreateMap<UpdateOrganizationDto, Organization>();
            CreateMap<Organization, OrganizationDetailDto>();
            CreateMap<Organization, OrganizationDto>()
                .ForMember(dest => dest.SpecializationIds, opt => opt.MapFrom(src => string.Join(", ", src.SpecializationIds)));
        }
    }
}
