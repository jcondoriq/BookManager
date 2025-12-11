using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.UseCases.BulkUploadBooks;
using BookManager.UseCases.CreateAuthor;
using BookManager.UseCases.CreateBook;
using BookManager.UseCases.DeleteAuthorById;
using BookManager.UseCases.DeleteBookById;
using BookManager.UseCases.GetAllAuthors;
using BookManager.UseCases.GetAllBooks;
using BookManager.UseCases.GetBookById;
using BookManager.UseCases.GetPagedAuthors;
using BookManager.UseCases.GetPagedBooks;
using BookManager.UseCases.Login;
using BookManager.UseCases.UpdateAuthor;
using BookManager.UseCases.UpdateBook;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCases(
            this IServiceCollection service)
        {
            service.AddScoped<ICreateAutorInputPort, CreateAutorInteractor>();
            service.AddScoped<IGetAllAuthorInputPort, GetAllAuthorsInteractor>();
            service.AddScoped<IDeleteAuthorByIdInputPort, DeleteAuthorByIdInteractor>();
            service.AddScoped<IUpdateAuthorInputPort, UpdateAuthorInteractor>();
            service.AddScoped<ICreateBookInputPort, CreateBookInteractor>();
            service.AddScoped<IGetAllBooksInputPort, GetAllBooksInteractor>();
            service.AddScoped<IGetBookByIdInputPort, GetBookByIdInteractor>();
            service.AddScoped<IDeleteBookByIdInputPort, DeleteBookByIdInteractor>();
            service.AddScoped<IUpdateBookInputPort, UpdateBookInteractor>();
            service.AddScoped<IGetPagedBooksInputPort, GetPagedBooksInteractor>();
            service.AddScoped<IGetPagedAuthorsInputPort, GetPagedAuthorsInteractor>();
            service.AddScoped<IBulkUploadBooksInputPort, BulkUploadBooksInteractor>();
            service.AddScoped<ILoginInputPort, LoginInteractor>();

            return service;
        }
    }
}
