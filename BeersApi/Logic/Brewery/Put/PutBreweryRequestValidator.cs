using FluentValidation;

namespace BeersApi.Logic.Brewery.Put
{
    public class PutbreweryRequestValidator : AbstractValidator<PutBreweryRequest>
    {
        public PutbreweryRequestValidator()
        {
            this.RuleFor(x => x.Name)
              .MinimumLength(3)
              .WithMessage("Name can't be shorter than 3 letters")
              .MaximumLength(40)
              .WithMessage("Name can't be longer than 40 letters")
              .NotEmpty()
              .WithMessage("Name can't be empty");

            this.RuleFor(x => x.City)
                 .MinimumLength(3)
                .WithMessage("City can't be shorter than 3 letters")
                .MaximumLength(40)
                .WithMessage("City can't be longer than 40 letters")
                .NotEmpty()
                .WithMessage("City can't be empty");

            this.RuleFor(x => x.Country)
                     .MinimumLength(3)
                     .WithMessage("City can't be shorter than 3 letters")
                     .MaximumLength(40)
                     .WithMessage("City can't be longer than 40 letters")
                     .NotEmpty()
                     .WithMessage("City can't be empty");

            this.RuleFor(x => x.Id)
                     .GreaterThanOrEqualTo(0)
                     .WithMessage("Id must be equal or greater than 0");
        }
    }
}

