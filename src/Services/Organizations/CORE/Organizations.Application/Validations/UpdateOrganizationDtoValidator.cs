using FluentValidation;
using Organizations.Application.Features.Organization.Requests.Commands;

namespace Organizations.Application.Validations
{
    public class UpdateOrganizationDtoValidator : AbstractValidator<UpdateOrganizationCommand>
    {
        public UpdateOrganizationDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.model.Level)
                .IsInEnum();
            RuleFor(x => x.model.Region)
                .IsInEnum();
            RuleFor(x => x.model.Address.Line)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.model.IsActive)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .Must(x => x == false || x == true).WithMessage("{PropertyName} is boolean value.");
            RuleFor(x => x.model.OrganizationName.OfficialName)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.model.OrganizationName.OfficialName)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
