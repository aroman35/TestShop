using FluentValidation;

namespace TestShop.Application.Products.Commands.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .WithMessage("Product amount should be greater than zero");

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("It is necessary to specify product's name")
                .Must(x => x.Length < 64)
                .WithMessage("Name should be less than 64 chars");

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("It is necessary to specify product's description");
        }
    }
}