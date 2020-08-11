using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TestShop.Application.Products.Commands.CreateProduct;
using TestShop.Application.Products.Queries.GetProductsList;
using TestShop.Domain.Entities;
using TestShop.WebApi.Models.RequestModels.Product;
using TestShop.WebApi.Models.ResponseModels.Abstractions;
using TestShop.WebApi.Options;

namespace TestShop.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly ProductsPageSettings _productsPageSettings;

        public ProductsController(IOptions<ProductsPageSettings> productsPageSettings)
        {
            _productsPageSettings = productsPageSettings.Value
                                    ?? throw new ArgumentException("Settings were not found", nameof(IOptions<ProductsPageSettings>));
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<ICollection<Product>>>> GetProductsList(
            [FromQuery] int page = 1)
        {
            var offset = page * _productsPageSettings.ProductsPerPage;
            var productsCount = _productsPageSettings.ProductsPerPage;

            var products = await Mediator.Send(new GetProductsListQuery(offset, productsCount));
            
            return new ActionResult<ResponseModel<ICollection<Product>>>(new ResponseModel<ICollection<Product>>(products));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreateProductRequestModel request)
        {
            await Mediator.Send(new CreateProductCommand(request.Name, request.Description, request.Amount));
            return NoContent();
        }
    }
}