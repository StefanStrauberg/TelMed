namespace IdentityServer.Core.Entities
{
    public enum AccountRole
    {
        /// <summary>
        /// Doctor
        /// </summary>
        Doctor = 1,
        /// <summary>
        /// Practitioner
        /// </summary>
        Practitioner = 2,
        /// <summary>
        /// Administrator
        /// </summary>
        Administrator = 3,
        /// <summary>
        /// Coordinator Practitioner
        /// </summary>
        CoordinatorPractitioner = 4,
        /// <summary>
        /// Coordinator Doctor
        /// </summary>
        CoordinatorDoctor = 5,
        /// <summary>
        /// Developer
        /// </summary>
        Developer = 9
    }
}