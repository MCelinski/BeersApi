using FluentValidation;

namespace BeersApi.Logic.Brewery.Delete
{
    public class DeleteBreweryRequestValidator : AbstractValidator<DeleteBreweryRequest>
    {
        public DeleteBreweryRequestValidator()
        {
            this.RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Id must be equal or greater than 0");
        }
    }
}
