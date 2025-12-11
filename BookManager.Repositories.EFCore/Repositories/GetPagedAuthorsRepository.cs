using BookManager.BusinessObjects.DTOs.Common;
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
    internal class GetPagedAuthorsRepository : IGetPagedAuthorsRepository
    {
        readonly BookManagerContext Context;

        public GetPagedAuthorsRepository(BookManagerContext context)
        {
            Context = context;
        }

        public async ValueTask<(IEnumerable<AuthorDto>, int)> GetPagedAsync(int page, int pageSize)
        {
            var query = Context.Authors
                                .AsNoTracking()
                                .AsQueryable();

            int totalItems = (page == 1) ? await query.CountAsync() : 0;

            var books = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(b => new AuthorDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    BirthDate = b.BirthDate
                })
                .ToListAsync();

            return (books, totalItems);
        }
    }
}
