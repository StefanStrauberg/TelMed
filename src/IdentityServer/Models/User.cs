using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public bool IsActive { get; set; }
        public string OrganizationId { get; set; }
        public string SpecializationId { get; set; }
        public string OfficePhone { get; set; }
    }
}