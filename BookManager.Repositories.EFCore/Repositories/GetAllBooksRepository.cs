using BookManager.BusinessObjects.DTOs.Common;
using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.Repositories.EFCore.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Repositories.EFCore.Repositories
{
    internal class GetAllBooksRepository : IGetAllBooksRepository
    {
        readonly BookManagerContext Context;

        public GetAllBooksRepository(BookManagerContext context)
        {
            Context = context;
        }

        public async ValueTask<List<BookDto>> GetAllBooksAsync()
        {
            var Books = await Context.Books
                .Select(x => new BookDto(x.Id, x.Isbn, x.Title, x.CoverUrl, x.PublicationYear, x.PageNumber, x.AuthorId))
                .ToListAsync();

            return Books;
        }
    }
}
