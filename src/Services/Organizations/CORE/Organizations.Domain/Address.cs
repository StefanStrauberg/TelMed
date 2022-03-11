namespace Organizations.Domain
{
    /// <summary>
    /// Full address of the organization
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Address
        /// </summary>
        public string Line { get { return Line; } set { Line = value.Trim(); } }
    }
}