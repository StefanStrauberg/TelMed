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
        public string UsualName { get; set; }
        /// <summary>
        /// Full name of the organization
        /// </summary>
        public string OfficialName { get; set; }
    }
}