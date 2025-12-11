using BookManager.BusinessObjects.DTOs.Common;
using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.Cross.Entities.Exceptions;
using BookManager.Repositories.EFCore.DataContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Repositories.EFCore.Repositories
{
    internal class GetBookByIdRepository : IGetBookByIdRepository
    {
        readonly BookManagerContext Context;

        public GetBookByIdRepository(BookManagerContext context)
        {
            Context = context;
        }

        public async ValueTask<BookDto> Get(Guid bookId)
        {
            var Book = await Context.Books.AsNoTracking().FirstOrDefaultAsync(a => a.Id == bookId);

            if (Book == null)
            {
                throw new ValidationException("Not Fount Book");
            }

            return new BookDto
            {
                Id = Book.Id,
                Isbn = Book.Isbn,
                Title = Book.Title,
                CoverUrl = Book.CoverUrl,
                PublicationYear = Book.PublicationYear,
                PageNumber = Book.PageNumber,
                AuthorId = Book.AuthorId
            };
        }
    }
}
