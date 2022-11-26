using FluentValidation;

namespace BeersApi.Logic.Category.Delete
{
    public class DeleteCategoryRequestValidator : AbstractValidator<DeleteCategoryRequest>
    {
        public DeleteCategoryRequestValidator()
        {
            this.RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Id must be equal or greater than 0");
        }
    }
}
