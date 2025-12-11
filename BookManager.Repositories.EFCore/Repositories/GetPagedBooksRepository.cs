using BookManager.BusinessObjects.DTOs.GetPagedBooks;
using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.Repositories.EFCore.DataContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Repositories.EFCore.Repositories
{
    internal class GetPagedBooksRepository : IGetPagedBooksRepository
    {
        readonly BookManagerContext Context;

        public GetPagedBooksRepository(BookManagerContext context)
        {
            Context = context;
        }

        public async ValueTask<(IEnumerable<BookItemDto>, int)> GetPagedAsync(string? normalizedSearch, int page, int pageSize)
        {
            var query = Context.Books
                                .AsNoTracking()
                                .Include(b => b.Author)
                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(normalizedSearch))
            {
                query = query.Where(b =>
                    b.NormalizedTitle.Contains(normalizedSearch) ||
                    b.Author.NormalizedName.Contains(normalizedSearch)
                );
            }

            int totalItems = (page == 1)?await query.CountAsync():0;

            var books = await query
                .OrderBy(b => b.Title)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(b => new BookItemDto
                {
                    Id = b.Id,
                    Isbn = b.Isbn,
                    Title = b.Title,
                    CoverUrl = b.CoverUrl,
                    PublicationYear = b.PublicationYear,
                    PageNumber = b.PageNumber,
                    AuthorName = b.Author.Name
                })
                .ToListAsync();

            return (books, totalItems);
        }
    }
}
