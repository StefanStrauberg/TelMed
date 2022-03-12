namespace Referrals.Domain.PatientEntity
{
    /// <summary>
    /// Full information about the patient
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Patient full name
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Patient gender
        /// </summary>
        public PatientGender Gender { get; set; }
        /// <summary>
        /// Patient date of birth
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}