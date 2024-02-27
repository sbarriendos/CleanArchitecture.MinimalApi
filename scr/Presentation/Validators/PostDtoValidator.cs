using Domain.Entites;
using FluentValidation;

namespace Presentation.Validators;
public class PostDtoValidator : AbstractValidator<PostEntity>
{
    public PostDtoValidator()
    {
        RuleFor(p => p.Content).NotEmpty().WithMessage("Content is required");
    }
}
