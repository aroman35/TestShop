using System;
using MediatR;

namespace TestShop.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public Guid Id;
        public readonly string Name;
        public readonly string Description;
        public readonly decimal Amount;

        public UpdateProductCommand(Guid id, string name, string description, decimal amount)
        {
            Id = id;
            Name = name;
            Description = description;
            Amount = amount;
        }
    }
}