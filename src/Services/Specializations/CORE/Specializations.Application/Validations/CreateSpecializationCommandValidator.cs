using FluentValidation;
using Specializations.Application.Features.Specialization.Requests.Commands;

namespace Specializations.Application.Validations
{
    public class CreateSpecializationCommandValidator : AbstractValidator<CreateSpecializationCommand>
    {
        public CreateSpecializationCommandValidator()
        {
            RuleFor(x => x.model.Name)
                .NotNull().WithMessage("{PropertyName} is cannot be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.model.DenyConsult)
                .Must(x => x == false || x == true).WithMessage("{PropertyName} must be true or false.");
        }
    }
}
