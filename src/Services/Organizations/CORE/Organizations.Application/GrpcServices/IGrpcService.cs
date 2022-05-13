namespace Organizations.Application.GrpcServices
{
    public interface IGrpcService
    {
        Task<string> GetSpecName(string id);
        Task<List<string>> GetSpecNamesByListIds(List<string> ids);
    }
}
