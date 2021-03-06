using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Domain
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
