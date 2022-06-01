using BaseDomain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizations.Domain
{
    /// <summary>
    /// Class describing the organization
    /// </summary>
    public class Organization : BaseDomainEntity
    {
        private string _arrderss;
        private string _usualName;
        private string _officialName;
        public OrganizationLevel Level { get; set; }
        public OrganizationRegion Region { get; set; }
        public string Address { get { return _arrderss; } set { _arrderss = value.Trim(); } }
        public bool IsActive { get; set; } = true;
        public string UsualName { get { return _usualName; } set { _usualName = value.Trim(); } }        
        public string OfficialName { get { return _officialName; } set { _officialName = value.Trim(); } }
        public IEnumerable<SpecializationIds> SpecializationIds { get; set; } = new List<SpecializationIds>();
    }
}
