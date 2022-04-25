using Specialization.GRPC.Entities.Common;

namespace Specialization.GRPC.Entities
{
    public class Specialization : BaseDomainEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool DenyConsult { get; set; }
    }
}
