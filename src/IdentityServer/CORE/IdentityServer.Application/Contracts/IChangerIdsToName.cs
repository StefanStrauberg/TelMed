namespace IdentityServer.Application.Contracts
{
    public interface IChangerIdsToName
    {
        Task<List<string>> Change(List<string> Ids);
        Task<string> SingleChange(string id);
    }
}
