using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.Repositories.EFCore.DataContexts;
using BookManager.Repositories.EFCore.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.Repositories.EFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services,
            IConfiguration configuration, string connectionStringName)
        {
            services.AddDbContext<BookManagerContext>(options =>
                        options.UseSqlite(
                            configuration.GetConnectionString(connectionStringName)));

            services.AddIdentityCore<IdentityUser>()
                    .AddEntityFrameworkStores<BookManagerContext>();

            services.AddScoped<ICreateAuthorRepository, CreateAuthorRepository>();
            services.AddScoped<IGetAllAuthorsRepository, GetAllAuthorsRepository>();
            services.AddScoped<IDeleteAuthorByIdRepository, DeleteAuthorByIdRepository>();
            services.AddScoped<IUpdateAuthorRepository, UpdateAuthorRepository>();
            services.AddScoped<IGetAuthorByIdRepository, GetAuthorByIdRepository>();
            services.AddScoped<ICreateBookRepository, CreateBookRepository>();
            services.AddScoped<IGetAllBooksRepository, GetAllBooksRepository>();
            services.AddScoped<IGetBookByIdRepository, GetBookByIdRepository>();
            services.AddScoped<IDeleteBookByIdRepository, DeleteBookByIdRepository>();
            services.AddScoped<IUpdateBookRepository, UpdateBookRepository>();
            services.AddScoped<IGetPagedBooksRepository, GetPagedBooksRepository>();
            services.AddScoped<IGetPagedAuthorsRepository, GetPagedAuthorsRepository>();
            services.AddScoped<IGetAuthorByNameRepository, GetAuthorByNameRepository>();
            services.AddScoped<IGetUserByCredentialsRepository, GetUserByCredentialsRepository>();

            return services;
        }
    }
}
