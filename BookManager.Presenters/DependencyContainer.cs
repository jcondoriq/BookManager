using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Presenters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenters(
            this IServiceCollection services,
            IConfigurationSection JWTConfigurationSection)
        {
            services.AddScoped<CreateAutorPresenter>();
            services.AddScoped<ICreateAutorPresenter>(provider => provider.GetService<CreateAutorPresenter>());
            services.AddScoped<ICreateAutorOutputPort>(provider => provider.GetService<CreateAutorPresenter>());


            services.AddScoped<GetAllAuthorsPresenter>();
            services.AddScoped<IGetAllAuthorsPresenter>(provider => provider.GetService<GetAllAuthorsPresenter>());
            services.AddScoped<IGetAllAuthorsOutputPort>(provider => provider.GetService<GetAllAuthorsPresenter>());

            services.AddScoped<CreateBookPresenter>();
            services.AddScoped<ICreateBookPresenter>(provider => provider.GetService<CreateBookPresenter>());
            services.AddScoped<ICreateBookOutputPort>(provider => provider.GetService<CreateBookPresenter>());

            services.AddScoped<GetAllBooksPresenter>();
            services.AddScoped<IGetAllBooksPresenter>(provider => provider.GetService<GetAllBooksPresenter>());
            services.AddScoped<IGetAllBooksOutputPort>(provider => provider.GetService<GetAllBooksPresenter>());

            services.AddScoped<GetBookByIdPresenter>();
            services.AddScoped<IGetBookByIdPresenter>(provider => provider.GetService<GetBookByIdPresenter>());
            services.AddScoped<IGetBookByIdOutputPort>(provider => provider.GetService<GetBookByIdPresenter>());

            services.AddScoped<GetPagedBooksPresenter>();
            services.AddScoped<IGetPagedBooksPresenter>(provider => provider.GetService<GetPagedBooksPresenter>());
            services.AddScoped<IGetPagedBooksOutputPort>(provider => provider.GetService<GetPagedBooksPresenter>());

            services.AddScoped<GetPagedAuthorsPresenter>();
            services.AddScoped<IGetPagedAuthorsPresenter>(provider => provider.GetService<GetPagedAuthorsPresenter>());
            services.AddScoped<IGetPagedAuthorsOutputPort>(provider => provider.GetService<GetPagedAuthorsPresenter>());

            services.AddScoped<BulkUploadBooksPresenter>();
            services.AddScoped<IBulkUploadBooksPresenter>(provider => provider.GetService<BulkUploadBooksPresenter>());
            services.AddScoped<IBulkUploadBooksOutputPort>(provider => provider.GetService<BulkUploadBooksPresenter>());

            services.AddScoped<LoginPresenter>(provider =>
                        new LoginPresenter(JWTConfigurationSection));
            services.AddScoped<ILoginPresenter>(provider => provider.GetService<LoginPresenter>());
            services.AddScoped<ILoginOutputPort>(provider => provider.GetService<LoginPresenter>());

            return services;
        }
    }
}
