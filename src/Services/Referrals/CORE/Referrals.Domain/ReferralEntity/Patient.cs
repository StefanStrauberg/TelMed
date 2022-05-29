namespace Referrals.Domain.ReferralEntity
{
    /// <summary>
    /// Patient full information - FullName, Gender, BirthDate
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Patient full name
        /// </summary>
        private string _FullName;
        public string FullName { get { return _FullName; } set { _FullName = value.Trim(); } }
        /// <summary>
        /// Patient gender
        /// </summary>
        public PatientGender Gender { get; set; }
        /// <summary>
        /// Patient date birth
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}