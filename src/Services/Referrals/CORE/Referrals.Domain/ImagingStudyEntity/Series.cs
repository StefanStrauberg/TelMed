namespace Referrals.Domain.ImagingStudyEntity
{
    public class Series
    {
        public string Modality { get; set; }
        public string Uid { get; set; }
        public int Number { get; set; }
        public int NumberOfInstances { get; set; }
        public string Url { get; set; }
        public int FrameRate { get; set; }
        public int NumberOfFrames { get; set; }
        public List<Instance> Instance { get; set; }
        public DateTime Started { get; set; }
    }
}