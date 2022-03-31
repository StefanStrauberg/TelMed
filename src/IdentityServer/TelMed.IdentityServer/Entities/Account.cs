using System;
using Microsoft.AspNetCore.Identity;

namespace TelMed.IdentityServer.Entities
{
    public class Account
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public bool IsActive { get; set; }
        public long OrganizationId { get; set; }
        public long? SpecializationId { get; set; }
        public long? WrongAttemptsCount { get; set; }
        public DateTime? LastWrongAttemptDateTime { get; set; }
        public string OfficePhone { get; set; }
    }
}