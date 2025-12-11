using BookManager.BusinessObjects.Interfaces.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.Controllers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddControllers(
            this IServiceCollection services)
        {
            services.AddScoped<ICreateAutorController, CreateAutorController>();
            services.AddScoped<IGetAllAuthorsController, GetAllAuthorsController>();
            services.AddScoped<IDeleteAuthorByIdController, DeleteAuthorByIdController>();
            services.AddScoped<IUpdateAuthorController, UpdateAuthorController>();
            services.AddScoped<ICreateBookController, CreateBookController>();
            services.AddScoped<IGetAllBooksController, GetAllBooksController>();
            services.AddScoped<IGetBookByIdController, GetBookByIdController>();
            services.AddScoped<IDeleteBookByIdController, DeleteBookByIdController>();
            services.AddScoped<IUpdateBookController, UpdateBookController>();
            services.AddScoped<IGetPagedBooksController, GetPagedBooksController>();
            services.AddScoped<IGetPagedAuthorsController, GetPagedAuthorsController>();
            services.AddScoped<IBulkUploadBooksController, BulkUploadBooksController>();
            services.AddScoped<ILoginController, LoginController>();

            return services;
        }
    }
}