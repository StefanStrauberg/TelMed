using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Domain
{
    public class Account : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public IdentityRole Role { get; set; }
        public string PasswordSalt { get; set; }
        public string RoleId { get; set; }
        public bool IsActive { get; set; } = true;
        public string OrganizationId { get; set; }
        public string SpecializationId { get; set; }
        public string OfficePhone { get; set; }
    }
}
