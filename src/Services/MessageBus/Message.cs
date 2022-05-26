namespace MessageBus
{
    public class Message
    {
        public string ReferralId { get; set; }
        public ReferralTask Task { get; set; }
        public string DataId { get; set; }
    }
}
