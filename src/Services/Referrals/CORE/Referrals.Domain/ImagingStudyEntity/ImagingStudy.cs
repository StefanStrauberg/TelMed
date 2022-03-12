namespace Referrals.Domain.ImagingStudyEntity
{
    public class ImagingStudy
    {
        public string Uid { get; set; }
        public DateTime Started { get; set; }
        public List<Series> Series { get; set; }
        public int NumberOfSeries => Series.Count;
        public int NumberOfInstances => Series.Sum(s => s.NumberOfInstances);
        public string Modality => Series.FirstOrDefault()?.Modality;
        public string Url { get; set; }
        public string Description { get; set; }
    }
}
