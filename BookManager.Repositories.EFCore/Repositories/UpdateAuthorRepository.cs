using BookManager.BusinessObjects.DTOs.Common;
using BookManager.BusinessObjects.DTOs.UpdateAuthor;
using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.Repositories.EFCore.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Repositories.EFCore.Repositories
{
    internal class UpdateAuthorRepository : IUpdateAuthorRepository
    {
        readonly BookManagerContext Context;

        public UpdateAuthorRepository(BookManagerContext context)
        {
            Context = context;
        }

        public async ValueTask Update(AuthorDto authorDto)
        {
            Context.Authors.Update(new Entities.Author
            {
                Id = authorDto.Id,
                Name = authorDto.Name,
                BirthDate = authorDto.BirthDate
            });

            await Context.SaveChangesAsync();
        }
    }
}
