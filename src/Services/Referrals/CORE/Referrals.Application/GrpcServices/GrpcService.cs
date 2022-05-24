using AutoMapper;
using IdentityServer.GRPC;

namespace Referrals.Application.GrpcServices
{
    public class GrpcService : IGrpcService
    {
        private readonly IdentityServerProtoService.IdentityServerProtoServiceClient _identityServerProtoService;
        private readonly IMapper _mapper;
        public GrpcService(
            IdentityServerProtoService.IdentityServerProtoServiceClient identityServerProtoService,
            IMapper mapper)
        {
            _identityServerProtoService = identityServerProtoService;
            _mapper = mapper;
        }
        public async Task<string> GetAccName(string id)
        {
            return _mapper.Map<string>(await _identityServerProtoService.GetAccNameByIdAsync(new GetAccIdRequest { Id = id }));
        } 
    }
}