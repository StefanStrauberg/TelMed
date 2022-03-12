﻿using FluentValidation;
using Specializations.Application.Features.Specialization.Requests.Commands;

namespace Specializations.Application.DTO
{
    public class UpdateSpecializationCommandValidator : AbstractValidator<UpdateSpecializationCommand>
    {
        public UpdateSpecializationCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("{PropertyName} is cannot be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("{PropertyName} is cannot be null.")
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(x => x.IsActive)
                .Must(x => x == false || x == true).WithMessage("{PropertyName} must be true or false.");

            RuleFor(x => x.DenyConsult)
                .Must(x => x == false || x == true).WithMessage("{PropertyName} must be true or false.");
        }
    }
}
