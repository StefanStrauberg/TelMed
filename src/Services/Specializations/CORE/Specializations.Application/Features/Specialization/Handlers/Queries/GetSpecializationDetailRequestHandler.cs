using MediatR;
using Specializations.Application.Contracts.Persistence;
using Specializations.Application.Exceptions;
using Specializations.Application.Features.Specialization.Requests.Queries;

namespace Specializations.Application.Features.Specialization.Handlers.Queries
{
    public class GetSpecializationDetailRequestHandler : IRequestHandler<GetSpecializationDetailRequest, Domain.Specialization>
    {
        private readonly ISpecializationRepository _repository;
        public GetSpecializationDetailRequestHandler(ISpecializationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Domain.Specialization> Handle(GetSpecializationDetailRequest request, CancellationToken cancellationToken)
        {
            var specialization = await _repository.GetAsync(request.Id);
            if(specialization is null)
                throw new NotFoundException(nameof(request), request.Id);
            return specialization;
        }
    }
}
