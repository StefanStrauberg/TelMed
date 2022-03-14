using AutoMapper;
using ReferralRequests.Application.Features.ReferralRequest.Requests.Commands;
using ReferralRequests.Domain;

namespace ReferralRequests.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReferralRequest, CreateReferralRequestCommand>().ReverseMap();
        }
    }
}
