using AutoMapper;

namespace Organization.GRPC.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GetOrgIdsRequestList, List<string>>()
                .ConvertUsing(src => src.Id.Select(id => id.ToString()).ToList());
            CreateMap<List<string>, OrgNamesList>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src));
        }
    }
}
