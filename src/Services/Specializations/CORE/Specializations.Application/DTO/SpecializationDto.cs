namespace Specializations.Application.DTO
{
    public class SpecializationDto
    {
        public string Id { get; set; }
        public DateTime Published { get; set; }
        public DateTime Updated { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool DenyConsult { get; set; }
    }
}
