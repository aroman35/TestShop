using TestShop.WebApi.Models.RequestModels.Abstractions;

namespace TestShop.WebApi.Models.RequestModels.Product
{
    public class CreateProductRequestModel : RequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}