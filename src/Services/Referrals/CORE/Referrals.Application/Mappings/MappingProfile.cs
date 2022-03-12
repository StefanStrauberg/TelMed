using AutoMapper;
using Referrals.Application.Features.Anamnesis.Requests.Commands;
using Referrals.Application.Features.Patient.Requests.Commands;
using Referrals.Application.Features.Referral.Requests.Commands;
using Referrals.Domain;
using Referrals.Domain.AnamnesisEntity;
using Referrals.Domain.PatientEntity;

namespace Referrals.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Referral, CreateReferralCommand>().ReverseMap();
            
            CreateMap<Patient, UpdatePatientCommand>().ReverseMap();
            
            CreateMap<Anamnesis, CreateAnamnesisCommand>().ReverseMap();
            CreateMap<Anamnesis, UpdateAnamnesisCommand>().ReverseMap();
        }
    }
}
