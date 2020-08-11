using TestShop.Domain.Abstract;

namespace TestShop.Domain.Entities
{
    public class ProductPhoto : AggregateRoot
    {
        public byte[] Large { get; set; }
        public byte[] Medium { get; set; }
        public byte[] Small { get; set; }
    }
}