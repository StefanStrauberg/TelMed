namespace Observations.Domain
{
    /// <summary>
    /// Image
    /// </summary>
    public class Attachment
    {
        private string _name;
        /// <summary>
        /// Image Name
        /// </summary>
        public string Name { get { return _name; } set { _name = value.Trim(); } }
        /// <summary>
        /// Image Size
        /// </summary>
        public ulong Size { get; set; }
        /// <summary>
        /// Image Url
        /// </summary>
        public string Url { get; set; }
    }
}