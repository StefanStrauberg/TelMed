using AutoMapper;

namespace Specialization.GRPC.Mapper
{
    public class SpecializationProfile : Profile
    {
        public SpecializationProfile()
        {
            CreateMap<string, SpecName>().ReverseMap();
        }
    }
}
