using BookzoneProjNituDaniel.Models.Input.Order;
using BookzoneProjNituDaniel.Repositories.Validation;
using FluentValidation;

namespace BookzoneProjNituDaniel.Models.Validators.Order
{
    public class CreateOrderValidator : ValidatorBase<CreateOrderInput>
    {
        public CreateOrderValidator(IValidationRepository validationRepository)
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId cannot be empty!")
                .Must((x, y) => validationRepository.UserExists(x.UserId)).WithMessage("User does not exist!");
            RuleFor(x => x.OrderProducts)
                .NotEmpty().WithMessage("OrderProducts cannot be empty!")
                .Must((order, orderProducts) =>
                {
                    return orderProducts.All(op => validationRepository.ProductExists(op.ProductId));
                })
                .WithMessage("One or more products do not exist!");
        }
    }
}
