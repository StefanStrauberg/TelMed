using AspNetCore.Identity.MongoDbCore.Models;

namespace IdentityServer.Domain
{
    public class ApplicationUser : MongoIdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public bool IsActive { get; set; } = true;
        public string OrganizationId { get; set; }
        public string SpecializationId { get; set; }
        public string OfficePhone { get; set; }
    }
}
