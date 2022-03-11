using FluentValidation;

namespace Organizations.Application.DTOs.Organization.Validators
{
    public class UpdateOrganizationDtoValidator : AbstractValidator<UpdateOrganizationDto>
    {
        public UpdateOrganizationDtoValidator()
        {
            Include(new OrganizationDtoValidator());

            RuleFor(x => x.Id)
                .NotNull().WithMessage("{PropertyName} is cannot be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
