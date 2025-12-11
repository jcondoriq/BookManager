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
    internal class GetAuthorByNameRepository : IGetAuthorByNameRepository
    {
        readonly BookManagerContext Context;

        public GetAuthorByNameRepository(BookManagerContext context)
        {
            Context = context;
        }

        public async ValueTask<AuthorDto> Get(string NormalizedName)
        {
            var author = await Context.Authors.AsNoTracking()
                                              .FirstOrDefaultAsync(a => a.NormalizedName == NormalizedName);

            if (author == null)
            {
                return default;
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
