using FluentValidation;

namespace BeersApi.Logic.Brewery.GetById
{
    public class GetBreweryByIdRequestValidator :AbstractValidator<GetBreweryByIdRequest>
    {
        public GetBreweryByIdRequestValidator()
        {
            this.RuleFor(x => x.Id)
                  .GreaterThanOrEqualTo(0)
                  .WithMessage("Id must be equal or greater than 0");
        }
    }
}
