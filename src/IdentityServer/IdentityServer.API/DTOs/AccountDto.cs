namespace IdentityServer.API.DTOs
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public bool IsActive { get; set; }
        public string OrganizationId { get; set; }
        public string SpecializationId { get; set; }
        public long? WrongAttemptsCount { get; set; }
        public DateTime? LastWrongAttemptDateTime { get; set; }
    }
}