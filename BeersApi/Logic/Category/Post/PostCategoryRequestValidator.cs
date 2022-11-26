using FluentValidation;

namespace BeersApi.Logic.Category.Post
{
    public class PostCategoryRequestValidator : AbstractValidator<PostCategoryRequest>
    {
        public PostCategoryRequestValidator()
        {
            this.RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage("Name can't be shorter than 3 letters")
                .MaximumLength(40)
                .WithMessage("Name can't be longer than 40 letters")
                .NotEmpty()
                .WithMessage("Name can't be empty");
        }
    }
}
