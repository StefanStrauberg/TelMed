namespace Organizations.Domain
{
    /// <summary>
    /// Name of the organization
    /// </summary>
    public class OrganizationName
    {
        private string _usualName;
        private string _officialName;
        /// <summary>
        /// Abbreviated name of the organization
        /// </summary>
        public string UsualName { get { return _usualName; } set { _usualName = value.Trim(); } }
        /// <summary>
        /// Full name of the organization
        /// </summary>
        public string OfficialName { get { return _officialName; } set { _officialName = value.Trim(); } }
    }
}