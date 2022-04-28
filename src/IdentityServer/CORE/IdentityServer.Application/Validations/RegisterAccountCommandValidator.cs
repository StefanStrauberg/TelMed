using System.Text.RegularExpressions;
using FluentValidation;
using IdentityServer.Application.Contracts.Persistence;
using IdentityServer.Application.Features.Account.Requests.Commands;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Application.Validations
{
    public class RegisterAccountCommandValidator : AbstractValidator<RegisterAccountCommand>
    {
        private readonly IAccountRepository _repository;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RegisterAccountCommandValidator(
            IAccountRepository repository,
            RoleManager<IdentityRole> roleManager)
        {
            _repository = repository;
            _roleManager = roleManager;
            RuleFor(x => x.model.UserName)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MustAsync(async (name, canncelation) =>
                {
                    return !await _repository.Exists(x => x.UserName == name);
                }).WithMessage("{PropertyName} already taken");
            RuleFor(x => x.model.FirstName)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.model.LastName)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.model.MiddleName)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.model.Password)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MinimumLength(8).MaximumLength(20)
                .Must(x => HasValidPassword(x)).WithMessage("{PropertyName} does not meet the requirements");
            RuleFor(x => x.model.ConfirmPassword)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Equal(x => x.model.Password).WithMessage("{PropertyName} do not tach");
            RuleFor(x => x.model.OrganizationId)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.model.SpecializationId)
                .NotNull().WithMessage("{PropertyName} not be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.model.Role)
                .NotNull()
                .NotEmpty()
                .MustAsync(async (name, canncelation) =>
                {
                    return await _roleManager.RoleExistsAsync(name);
                }).WithMessage("{PropertyName} invalid role");
        }
        private bool HasValidPassword(string pw)
        {
        	var lowercase = new Regex("[a-z]+");
        	var uppercase = new Regex("[A-Z]+");
        	var digit = new Regex("(\\d)+");
        	var symbol = new Regex("(\\W)+");
        	return (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw));
        }
    }
}
