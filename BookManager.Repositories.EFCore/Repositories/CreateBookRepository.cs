using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.BusinessObjects.POCOEntities;
using BookManager.Repositories.EFCore.DataContexts;
using Repository = BookManager.Repositories.EFCore.Entities;

namespace BookManager.Repositories.EFCore.Repositories
{
    internal class CreateBookRepository : ICreateBookRepository
    {
        readonly BookManagerContext Context;

        public CreateBookRepository(BookManagerContext context)
        {
            Context = context;
        }

        public async ValueTask Create(Book book)
        {
            Repository.Book authorEntity = new()
            {
                Id = book.Id,
                Title = book.Title,
                NormalizedTitle = book.NormalizedTitle,
                AuthorId = book.AuthorId,
                PageNumber = book.PageNumber,
                PublicationYear = book.PublicationYear,
                Isbn = book.Isbn,
                CoverUrl = book.CoverUrl
            };

            await Context.Books.AddAsync(authorEntity);
            await Context.SaveChangesAsync();
        }
    }
}
