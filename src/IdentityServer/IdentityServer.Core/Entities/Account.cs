using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Core.Entities
{
    public class Account : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Role Role { get; set;}
        public bool IsActive { get; set; } = true;
        public string OrganizationId { get; set; }
        public string SpecializationId { get; set; }
        public long? WrongAttemptsCount { get; set; }
        public DateTime? LastWrongAttemptDateTime { get; set; }
    }
}
