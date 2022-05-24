namespace Referrals.Application.GrpcServices
{
    public interface IGrpcService
    {
        Task<string> GetAccName(string id);
    }
}