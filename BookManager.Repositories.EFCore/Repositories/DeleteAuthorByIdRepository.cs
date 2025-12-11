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
    internal class DeleteAuthorByIdRepository : IDeleteAuthorByIdRepository
    {
        readonly BookManagerContext Context;

        public DeleteAuthorByIdRepository(BookManagerContext context)
        {
            Context = context;
        }

        public async ValueTask DeleteById(Guid authorId)
        {
            var author = await Context.Authors.FindAsync(authorId);

            if (author == null)
                throw new ValidationException("El identificador del autor no existe.");

            Context.Authors.Remove(author);
            await Context.SaveChangesAsync();
        }
    }
}
