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
    internal class GetAuthorByIdRepository : IGetAuthorByIdRepository
    {
        readonly BookManagerContext Context;

        public GetAuthorByIdRepository(BookManagerContext context)
        {
            Context = context;
        }

        public async ValueTask<AuthorDto> Get(Guid authorId)
        {
            var author = await Context.Authors.AsNoTracking().FirstOrDefaultAsync(a => a.Id == authorId);

            if (author == null)
            {
                throw new ValidationException("Not Fount Author");
            }

            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                BirthDate = author.BirthDate
            };
        }
    }
}
