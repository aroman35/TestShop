using System;
using MediatR;

namespace TestShop.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public readonly Guid Id;

        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }
}