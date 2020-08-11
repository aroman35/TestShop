using System.Collections.Generic;
using MediatR;
using TestShop.Domain.Entities;

namespace TestShop.Application.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<ICollection<Product>>
    {
        public readonly int Offset;
        public readonly int Count;

        public GetProductsListQuery(int offset, int count)
        {
            Offset = offset;
            Count = count;
        }
    }
}