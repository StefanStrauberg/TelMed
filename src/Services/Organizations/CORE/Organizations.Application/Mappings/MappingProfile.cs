using AutoMapper;
using Organizations.Application.DTO;
using Organizations.Domain;
using Specialization.GRPC;

namespace Organizations.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOrganizationDto, Organization>();
            CreateMap<UpdateOrganizationDto, Organization>();
            CreateMap<Organization, OrganizationDetailDto>();
            CreateMap<List<string>, GetSpecIdsRequestList>();
            CreateMap<SpecNamesList, List<string>>();
            CreateMap<Organization, OrganizationDto>()
                .ForMember(dest => dest.SpecializationIds, opt => opt.MapFrom(src => string.Join(", ", src.SpecializationIds)));
        }
    }
}
