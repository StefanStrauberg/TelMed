using Anamnesies.Application.Contracts.Persistence;
using Anamnesies.Application.Exceptions;
using Anamnesies.Application.Features.Referral.Requests.Queries;
using Anamnesies.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Anamnesies.Application.Features.Referral.Handlers.Queries
{
    public class GetAnamnesisDetailRequestHandler : IRequestHandler<GetAnamnesisDetailRequest, Anamnesis>
    {
        private readonly IAnamnesisRepository _repository;
        public GetAnamnesisDetailRequestHandler(
            IAnamnesisRepository repository)
        {
            _repository = repository;
        }
        public async Task<Anamnesis> Handle(GetAnamnesisDetailRequest request, CancellationToken cancellationToken)
        {
            var anamnesis = await _repository.GetAsync(request.Id);
            if (anamnesis is null)
                throw new NotFoundException(nameof(request), request.Id);
            return anamnesis;
        }
    }
}
