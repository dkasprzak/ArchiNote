using FluentValidation;

namespace ArchiNote.Application.Organizations.RegisterOrganization;

public class RegisterOrganizationCommandValidator : AbstractValidator<RegisterOrganizationCommand>
{
    public RegisterOrganizationCommandValidator()
    {
       RuleFor(o => o.FullName)
           .NotEmpty()
           .WithMessage("FullName is required.")
           .MaximumLength(200)
           .WithMessage("FullName must not exceed 200 characters.");
       
       RuleFor(o => o.ShortName)
           .MaximumLength(50)
           .WithMessage("ShortName must not exceed 50 characters.")
           .Must((model, shortName) => string.IsNullOrEmpty(shortName) || shortName.Length <= model.FullName?.Length)
           .WithMessage("ShortName cannot be longer than FullName.");;
       
       RuleFor(o => o.Email)
           .NotEmpty()
           .WithMessage("Email address is required")
           .EmailAddress()
           .WithMessage("Please enter a valid email address")
           .MaximumLength(200)
           .WithMessage("Email must not exceed 200 characters.");
       
       RuleFor(o => o.ConfirmEmail)
           .Equal(o => o.Email)
           .WithMessage("Email doesn't match.");

       RuleFor(o => o.FirstName)
           .NotEmpty()
           .WithMessage("FirstName is required.")
           .MaximumLength(200)
           .WithMessage("FirstName must not exceed 200 characters.");
       
       RuleFor(o => o.LastName)
           .NotEmpty()
           .WithMessage("FirstName is required.")
           .MaximumLength(200)
           .WithMessage("LastName must not exceed 200 characters.");

       RuleFor(o => o.Password)
           .NotEmpty()
           .WithMessage("Password is required.")
           .MinimumLength(10)
           .WithMessage("Password must be at least 10 characters long.")
           .Must(password => password?.Any(c => "!@#$%^&*()_+-=[]{}|;:,.<>?".Contains(c)) == true)
           .WithMessage("Password must contain at least one special character.")
           .Must(password => password?.Any(char.IsUpper) == true)
           .WithMessage("Password must contain at least one uppercase letter.")
           .Must(password => password?.Any(char.IsLower) == true)
           .WithMessage("Password must contain at least one lowercase letter.")
           .Must(password => password?.Any(char.IsDigit) == true)
           .WithMessage("Password must contain at least one digit.");;
       
       RuleFor(o => o.ConfirmPassword)
           .Equal(o => o.Password)
           .WithMessage("Passwords do not match.");

    }
}