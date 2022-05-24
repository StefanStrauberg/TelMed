namespace IdentityServer.GRPC.DbContexts.Config
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionNameAccounts { get; set; }
    }
}
