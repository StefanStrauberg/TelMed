namespace Organizations.Domain
{
    /// <summary>
    /// Name of the organization
    /// </summary>
    public class OrganizationName
    {
        /// <summary>
        /// Abbreviated name of the organization
        /// </summary>
        public string UsualName { get { return UsualName; } set { UsualName = value.Trim(); } }
        /// <summary>
        /// Full name of the organization
        /// </summary>
        public string OfficialName { get { return OfficialName; } set { OfficialName = value.Trim(); } }
    }
}