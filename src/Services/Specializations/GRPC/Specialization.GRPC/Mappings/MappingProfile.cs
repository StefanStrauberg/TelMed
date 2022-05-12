using AutoMapper;

namespace Specialization.GRPC.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GetSpecIdsRequestList, List<string>>();
            CreateMap<List<string>, SpecNamesList>();
        }
    }
}
