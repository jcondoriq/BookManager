using BookManager.BusinessObjects.DTOs.BulkUploadBooks;
using BookManager.BusinessObjects.DTOs.Common;
using BookManager.BusinessObjects.DTOs.CreateAutor;
using BookManager.BusinessObjects.DTOs.CreateBook;
using BookManager.BusinessObjects.DTOs.GetPagedAuthors;
using BookManager.BusinessObjects.DTOs.GetPagedBooks;
using BookManager.BusinessObjects.DTOs.UpdateAuthor;
using BookManager.BusinessObjects.DTOs.UpdateBook;
using BookManager.Validators.BookCommon;
using BookManager.Validators.BulkUploadBooks;
using BookManager.Validators.CreateAuthor;
using BookManager.Validators.CreateBook;
using BookManager.Validators.GetPagedAuthors;
using BookManager.Validators.GetPagedBooks;
using BookManager.Validators.UpdateAuthor;
using BookManager.Validators.UpdateBook;

namespace BookManager.Validators
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddValidators(
            this IServiceCollection services)
        {
            services.AddScoped<Cross.Entities.Interfaces.IValidator<CreateAuthorDto>,
                CreateAuthorDtoValidator>();

            services.AddScoped<Cross.Entities.Interfaces.IValidator<UpdateAuthorDto>,
                UpdateAuthorValidator>();

            services.AddScoped<Cross.Entities.Interfaces.IValidator<CreateBookDto>,
                CreateBookDtoValidator>();

            services.AddScoped<Cross.Entities.Interfaces.IValidator<BookIdDto>,
                BookIdDtoValidator>();

            services.AddScoped<Cross.Entities.Interfaces.IValidator<UpdateBookDto>,
                UpdateBookDtoValidator>();

            services.AddScoped<Cross.Entities.Interfaces.IValidator<GetPagedBooksRequestDto>,
                GetPagedBooksRequestDtoValidator>();

            services.AddScoped<Cross.Entities.Interfaces.IValidator<GetPagedAuthorsRequestDto>,
                GetPagedAuthorsRequestDtoValidator>();

            services.AddScoped<Cross.Entities.Interfaces.IValidator<BulkUploadBooksRequestDto>,
                BulkUploadBooksRequestDtoValidator>();

            return services;
        }
    }
}
