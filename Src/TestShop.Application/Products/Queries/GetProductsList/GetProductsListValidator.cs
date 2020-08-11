using FluentValidation;

namespace TestShop.Application.Products.Queries.GetProductsList
{
    public class GetProductsListValidator : AbstractValidator<GetProductsListQuery>
    {
        public GetProductsListValidator()
        {
            RuleFor(x => x.Offset)
                .GreaterThan(0)
                .WithMessage("Offset should be a valid positive number");

            RuleFor(x => x.Offset)
                .GreaterThan(0)
                .WithMessage("Products count should be greater than zero");
        }
    }
}