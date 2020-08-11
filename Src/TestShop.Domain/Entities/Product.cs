using System;
using TestShop.Domain.Abstract;

namespace TestShop.Domain.Entities
{
    public class Product : AggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public Guid? PhotoId { get; set; }

        public Product(string name, string description, decimal amount)
        {
            UpdateState(name, description, amount);
        }

        public void UpdateState(string name, string description, decimal amount)
        {
            Name = name;
            Description = description;
            Amount = amount;

            StateUpdated();
        }
    }
}