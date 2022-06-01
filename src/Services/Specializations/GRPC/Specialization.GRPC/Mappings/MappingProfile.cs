using AutoMapper;

namespace Specialization.GRPC.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GetSpecIdsRequestList,List<Guid>>()
                .ConvertUsing(src => src.Id.Select(id => new Guid(id)).ToList());
            CreateMap<List<string>, SpecNamesList>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src));
        }
    }
}
