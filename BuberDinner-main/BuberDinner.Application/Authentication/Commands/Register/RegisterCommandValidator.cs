using FluentValidation;

namespace BuberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x=> x.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x=> x.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(v => v.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not valid.");

        RuleFor(v => v.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
            .Matches("[A-Z]").WithMessage("Password must contain 1 uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain 1 lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain a number.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain non alphanumeric.");
    }
}