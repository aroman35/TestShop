using System;

namespace TestShop.Application.Exceptions
{
    public class NotFoundException : TestShopApplicationException
    {
        public readonly string ItemType;
        public readonly Guid ItemId;

        public NotFoundException(string itemType, Guid itemId)
        {
            ItemType = itemType;
            ItemId = itemId;
        }
    }
}