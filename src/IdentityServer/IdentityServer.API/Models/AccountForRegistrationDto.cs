using System.ComponentModel.DataAnnotations;

namespace IdentityServer.API.Models
{
    public class AccountForRegistrationDto
    {
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string OrganizationId { get; set; }
        public string PhoneNumber { get; set; }
        public string OfficePhone { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        public string SpecializationId { get; set; }
    }
}