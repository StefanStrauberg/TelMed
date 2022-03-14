using AutoMapper;
using ImagingStudies.Application.Features.ImagingStudiy.Requests.Commands;
using ImagingStudies.Domain;

namespace ImagingStudies.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ImagingStudy, CreateImagingStudiyCommand>().ReverseMap();
            CreateMap<ImagingStudy, UpdateImagingStudiyCommand>().ReverseMap();
        }
    }
}
