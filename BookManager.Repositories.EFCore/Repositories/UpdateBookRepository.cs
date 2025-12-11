using BookManager.BusinessObjects.DTOs.Common;
using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.Repositories.EFCore.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Repositories.EFCore.Repositories
{
    internal class UpdateBookRepository : IUpdateBookRepository
    {
        readonly BookManagerContext Context;

        public UpdateBookRepository(BookManagerContext context)
        {
            Context = context;
        }

        public async ValueTask Update(BookDto bookDto)
        {
            Context.Books.Update(new Entities.Book
            {
                Id = bookDto.Id,
                Isbn = bookDto.Isbn,
                Title = bookDto.Title,
                CoverUrl = bookDto.CoverUrl,
                PublicationYear = bookDto.PublicationYear,
                PageNumber = bookDto.PageNumber,
                AuthorId = bookDto.AuthorId                
            });

            await Context.SaveChangesAsync();
        }
    }
}
