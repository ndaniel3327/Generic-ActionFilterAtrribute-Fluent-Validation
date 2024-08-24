using BookzoneProjNituDaniel.Models.Input.Product;
using FluentValidation;

namespace BookzoneProjNituDaniel.Models.Validators.Product
{
    public class CreateProductValidator : ValidatorBase<CreateProductInput>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required !")
                .Length(2, 50).WithMessage("Product name must be between 2 and 30 characters.");
            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("{PropertyName} should be greater than 0!");
        }
    }
}
