using FluentValidation;

namespace ArchiNote.Application.Projects.Create;

public sealed class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MaximumLength(200);
        RuleFor(p => p.Status).IsInEnum();
    }
}