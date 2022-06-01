namespace Specializations.Application.DTO
{
    public class SpecializationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool DenyConsult { get; set; }
    }
}
