using FluentValidation;
using NvsFood.Infrastructure.Requests;

namespace NvsFood.Application.UseCases.User.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty.");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty.");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email address.");
        RuleFor(x => x.Password).MinimumLength(6).WithMessage("Password must be at least 6 characters.");
    }
}