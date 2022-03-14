using ImagingStudies.Domain.Common;

namespace ImagingStudies.Domain
{
    public class ImagingStudy : BaseDomainEntity
    {
        public string ReferralId { get; set; }
        public string Uid { get; set; }
        public DateTime Started { get; set; }
        public int NumberOfSeries => Series.Count;
        public int NumberOfInstances => Series.Sum(s => s.NumberOfInstances);
        public string Modality => Series.FirstOrDefault()?.Modality;
        public List<Series> Series { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }
}
