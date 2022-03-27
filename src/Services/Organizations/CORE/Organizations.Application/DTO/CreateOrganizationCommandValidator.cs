using FluentValidation;
using Organizations.Application.Features.Organization.Requests.Commands;

namespace Organizations.Application.DTO
{
    public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
    {
        public CreateOrganizationCommandValidator()
        {
            RuleFor(x => x.Level)
                .IsInEnum().WithMessage("{PropertyName} has a range of values which does not include '{PropertyValue}'.");

            RuleFor(x => x.Region)
                .IsInEnum().WithMessage("{PropertyName} has a range of values which does not include '{PropertyValue}'.");

            RuleFor(x => x.Address.Line)
                .NotNull().WithMessage("{PropertyName} is cannot be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.OrganizationName.UsualName)
                .NotNull().WithMessage("{PropertyName} is cannot be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.OrganizationName.OfficialName)
                .NotNull().WithMessage("{PropertyName} is cannot be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
