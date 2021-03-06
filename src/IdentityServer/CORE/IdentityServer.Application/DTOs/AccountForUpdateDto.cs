namespace IdentityServer.Application.DTOs
{
    public class AccountForUpdateDto
    {
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Role { get; set; }
        public string OrganizationId { get; set; }
        public string PhoneNumber { get; set; }
        public string OfficePhone { get; set; }
        public string Email { get; set; }
        public string SpecializationId { get; set; }
    }
}
