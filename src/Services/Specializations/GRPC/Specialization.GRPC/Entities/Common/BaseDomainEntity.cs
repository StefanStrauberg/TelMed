namespace Specialization.GRPC.Entities.Common
{
    public abstract class BaseDomainEntity
    {
        public string Id { get; set; }
        public DateTime Published { get; set; }
        public DateTime Updated { get; set; }
    }
}
