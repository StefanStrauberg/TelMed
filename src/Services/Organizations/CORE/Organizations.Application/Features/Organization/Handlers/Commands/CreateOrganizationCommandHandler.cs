using AutoMapper;
using MediatR;
using Organizations.Application.Contracts.Persistence;
using Organizations.Application.Features.Organization.Requests.Commands;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Organizations.Application.Features.Organization.Handlers.Commands
{
    public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateOrganizationCommandHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateOrganizationCommand request, 
            CancellationToken cancellationToken)
        {
            await _unitOfWork.Organizations.Add(_mapper.Map<Domain.Organization>(request.model));
            await _unitOfWork.Complete();

            var insertingData = await _unitOfWork.Organizations.FindWithExpressionAsync(x => x.UsualName == request.model.UsualName);
            var _options = new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
            var jsonString = JsonSerializer.Serialize(insertingData, _options);
            File.WriteAllText("Colleges.json", jsonString);


            return Unit.Value;
        }
    }
}
