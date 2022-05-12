using AutoMapper;

namespace Organization.GRPC.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GetOrgIdsRequestList, List<string>>();
            CreateMap<List<string>, OrgNameList>();
        }
    }
}
