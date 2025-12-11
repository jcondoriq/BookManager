using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.Cross.Entities
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddEntitiesCrossServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(ValidateService<>));

            var externalApis = configuration
                .GetSection("ExternalApis")
                .Get<List<ExternalApiConfig>>();

            foreach (var api in externalApis)
            {
                services.AddHttpClient(api.Name, c =>
                {
                    c.BaseAddress = new Uri(api.BaseUrl);
                    c.Timeout = TimeSpan.FromSeconds(30);
                });
            }

            services.AddSingleton<IApiContextFactory, ApiContextFactory>();

            services.AddSingleton<INormalizationRule, UpperCaseRule>();
            services.AddSingleton<INormalizationRule, RemoveNumbersRule>();
            services.AddSingleton<INormalizationRule, RemoveDiacriticsRule>();
            services.AddSingleton<INormalizationRule, CollapseSpacesRule>();

            services.AddSingleton<IStringNormalizer, StringNormalizer>();

            return services;
        }
    }
}
