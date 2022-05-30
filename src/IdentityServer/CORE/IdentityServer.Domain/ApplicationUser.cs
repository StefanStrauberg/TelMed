using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Domain
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string OrganizationId { get; set; }
        public string SpecializationId { get; set; }
        public string OfficePhone { get; set; }
        // Specific field store users roles in table database for fasted getting roles
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
