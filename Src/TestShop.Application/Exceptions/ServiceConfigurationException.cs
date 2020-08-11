using System;

namespace TestShop.Application.Exceptions
{
    public class ServiceConfigurationException : TestShopApplicationException
    {
        public readonly Type ServiceType;

        public ServiceConfigurationException(Type serviceType)
        {
            ServiceType = serviceType;
        }
    }
}