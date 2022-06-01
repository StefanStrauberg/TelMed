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
            CreateMap<Organization, OrganizationDetailDto>();
            CreateMap<UpdateOrganizationDto, Organization>();
            CreateMap<List<string>, GetSpecIdsRequestList>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src));
            CreateMap<SpecNamesList, List<string>>()
                .ConvertUsing(src => src.Name.Select(name => name.ToString()).ToList());
            CreateMap<Organization, OrganizationDto>()
                .ForMember(dest => dest.SpecializationIds, opt => opt.MapFrom(src => string.Join(", ", src.SpecializationIds)));
        }
    }
}
