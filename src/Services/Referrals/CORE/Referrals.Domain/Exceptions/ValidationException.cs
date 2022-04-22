namespace Referrals.Domain.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(IReadOnlyDictionary<string, string[]> errorsDictionary) 
            : base("Validation Failoure", "One or more validation errors occurred")
            => ErrorsDictionary = errorsDictionary;
        public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; set; }
    }
}
