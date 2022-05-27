﻿using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.DTOs
{
    public class AccountDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string OrganizationId { get; set; }
        public string PhoneNumber { get; set; }
        public string OfficePhone { get; set; }
        public string Email { get; set; }
        public string SpecializationId { get; set; }
        public bool IsActive { get; set; }
    }
}
