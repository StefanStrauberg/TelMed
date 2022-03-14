namespace Organizations.Domain
{
    /// <summary>
    /// Full address of the organization
    /// </summary>
    public class Address
    {
        private string _line;
        /// <summary>
        /// Address
        /// </summary>
        public string Line { get { return _line; } set { _line = value.Trim(); } }
    }
}