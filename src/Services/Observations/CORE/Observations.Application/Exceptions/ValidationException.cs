using FluentValidation.Results;

namespace Observations.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException() : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(x => x.PropertyName, x => x.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
        public Dictionary<string, string[]> Errors { get; }
    }
}
