using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.Cross.Entities.Exceptions;
using BookManager.Repositories.EFCore.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Repositories.EFCore.Repositories
{
    internal class DeleteBookByIdRepository : IDeleteBookByIdRepository
    {
        readonly BookManagerContext Context;

        public DeleteBookByIdRepository(BookManagerContext context)
        {
            Context = context;
        }

        public async ValueTask Delete(Guid bookId)
        {
            var Book = await Context.Books.FindAsync(bookId);

            if (Book == null)
                throw new ValidationException("El identificador del autor no existe.");

            Context.Books.Remove(Book);
            await Context.SaveChangesAsync();
        }
    }
}
