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
    internal class GetAllAuthorsRepository : IGetAllAuthorsRepository
    {
        readonly BookManagerContext Context;
        public GetAllAuthorsRepository(BookManagerContext context)
        {
            Context = context;
        }
        public async ValueTask<List<AuthorDto>> GetAllAuthorsAsync()
        {
            var authors = await Context.Authors
                .Select(x => new AuthorDto(x.Id, x.Name, x.BirthDate))
                .ToListAsync();

            return authors;
        }
    }
}
