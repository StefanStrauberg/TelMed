using FluentValidation;
using IdentityServer.Application.Features.Account.Requests.Commands;

namespace IdentityServer.Application.Validations
{
    public class LoginAccountCommandValidatior : AbstractValidator<LoginAccountCommand>
    {
        public LoginAccountCommandValidatior()
        {
            RuleFor(x => x.model.Login)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.model.Password)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
