using Domain.Models;
using FluentValidation;

namespace Presentation.Validators;
public class PostValidator : AbstractValidator<Post>
{
    public PostValidator()
    {
        RuleFor(p => p.Content).NotEmpty().WithMessage("Content is required");
    }
}
