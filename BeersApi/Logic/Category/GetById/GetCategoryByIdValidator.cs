using FluentValidation;

namespace BeersApi.Logic.Category.GetById
{
    public class GetCategoryByIdValidator : AbstractValidator<GetCategoryByIdRequest>
    {
        public GetCategoryByIdValidator()
        {
            this.RuleFor(x => x.Id)
               .GreaterThanOrEqualTo(0)
               .WithMessage("Id must be equal or greater than 0");
        }
    }
}
