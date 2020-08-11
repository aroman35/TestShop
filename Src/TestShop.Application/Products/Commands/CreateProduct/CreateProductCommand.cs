using MediatR;

namespace TestShop.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest
    {
        public readonly string Name;
        public readonly string Description;
        public readonly decimal Amount;

        public CreateProductCommand(string name, string description, decimal amount)
        {
            Name = name;
            Description = description;
            Amount = amount;
        }
    }
}