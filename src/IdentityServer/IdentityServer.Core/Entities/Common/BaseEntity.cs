namespace IdentityServer.Core.Entities.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Published { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
    }
}
