using FluentValidation;

namespace Organizations.Application.DTOs.Organization.Validators
{
    public class CreateOrganizationDtoValidator : AbstractValidator<CreateOrganizationDto>
    {
        public CreateOrganizationDtoValidator()
        {
            Include(new OrganizationDtoValidator());
        }
    }
}
