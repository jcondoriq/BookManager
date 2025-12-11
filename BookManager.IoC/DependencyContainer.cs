
using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.Controllers;
using BookManager.Cross.Entities;
using BookManager.Cross.ExceptionHandlers;
using BookManager.ExternalServices;
using BookManager.Presenters;
using BookManager.Repositories.EFCore;
using BookManager.Repositories.EFCore.DataContexts;
using BookManager.Repositories.EFCore.Repositories;
using BookManager.UseCases;
using BookManager.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddBookManagerServices(
            this IServiceCollection services,
            IConfiguration configuration, string connectionStringName, IConfigurationSection JWTConfigurationSection)
        {
            services
                .AddUseCases()
                .AddControllers()
                .AddPresenters(JWTConfigurationSection)
                .AddRepositories(configuration, connectionStringName)
                .AddEntitiesCrossServices(configuration)
                .AddValidators()
                .AddWebExceptionHandler()
                .AddExternalServices();

            return services;
        }
    }
}