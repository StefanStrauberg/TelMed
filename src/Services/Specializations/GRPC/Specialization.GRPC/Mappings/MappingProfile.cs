using AutoMapper;

namespace Specialization.GRPC.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GetSpecIdsRequestList,List<string>>()
                .ConvertUsing(src => src.Id.Select(id => id.ToString()).ToList());
            CreateMap<List<string>, SpecNamesList>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src));
        }
    }
}
