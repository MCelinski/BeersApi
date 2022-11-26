using FluentValidation;

namespace BeersApi.Logic.Category.Put
{
    public class PutCategoryRequestValidator :AbstractValidator<PutCategoryRequest>
    {
        public PutCategoryRequestValidator()
        {
            this.RuleFor(x => x.Id)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Id must be equal or greater than 0");

            this.RuleFor(x => x.Name)
                .MaximumLength(40)
                .MinimumLength(3);
        }
    }
}
