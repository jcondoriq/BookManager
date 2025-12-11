using BookManager.BusinessObjects.Interfaces.ExternalServices;
using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.ExternalServices.OpenLibrary;
using BookManager.ExternalServices.SoapClient;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.ExternalServices
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddExternalServices(
            this IServiceCollection service)
        {
            service.AddScoped<IGetCoverUrlByIsbnExternalService, GetCoverUrlByIsbnExternalService>();
            service.AddScoped<IValidateIsbnExternalService, ValidateIsbnExternalService>();

            return service;
        }
    }
}
