using FluentValidation;

namespace Organizations.Application.Features.Organization.Requests.Commands
{
    public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
    {
        public CreateOrganizationCommandValidator()
        {
            RuleFor(x => x.Level)
                .IsInEnum();
            RuleFor(x => x.Region)
                .IsInEnum();
            RuleFor(x => x.Address.Line)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.OrganizationName.OfficialName)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.OrganizationName.OfficialName)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
