using Specializations.Domain.Common;

namespace Specializations.Domain
{
    public class Specialization : BaseDomainEntity
    {
        /// <summary>
        /// Division name
        /// </summary>
        public string Name { get; set;  }
        public bool IsActive { get; set; }
        public bool DenyConsult { get; set; }
    }
}
