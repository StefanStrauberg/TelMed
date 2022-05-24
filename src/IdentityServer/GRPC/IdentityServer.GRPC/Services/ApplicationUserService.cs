using Grpc.Core;
using IdentityServer.GRPC.Repositories;

namespace IdentityServer.GRPC.Services
{
    public class ApplicationUserService : IdentityServerProtoService.IdentityServerProtoServiceBase
    {
        private readonly IApplicationUserRepository _repository;
        public ApplicationUserService(IApplicationUserRepository repository)
            => _repository = repository;
        public override async Task<AccName> GetAccNameById(GetAccIdRequest request, ServerCallContext context)
        {
            var data = new AccName { Name = await _repository.GetAccNameAsync(request.Id) };
            return data;
        }
    }
}
