namespace ImagingStudies.Domain
{
    public class Instance
    {
        public int? Number { get; set; }
        public string Uid { get; set; }
        public string SopClass { get; set; }
        public Attachment Content { get; set; }
    }
}