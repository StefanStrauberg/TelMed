namespace Referrals.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public string Id { get; set; }
        public DateTime Published { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
    }
}
