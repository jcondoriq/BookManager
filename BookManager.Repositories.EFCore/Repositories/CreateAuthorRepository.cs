using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.BusinessObjects.POCOEntities;
using BookManager.Repositories.EFCore.DataContexts;
using Repository = BookManager.Repositories.EFCore.Entities;

namespace BookManager.Repositories.EFCore.Repositories
{
    internal class CreateAuthorRepository : ICreateAuthorRepository
    {
        readonly BookManagerContext Context;

        public CreateAuthorRepository(BookManagerContext context)
        {
            Context = context;
        }

        public async ValueTask CreateAuthorAsync(Author author)
        {
            Repository.Author authorEntity = new()
            {
                Id = author.Id,
                Name = author.Name,
                NormalizedName = author.NormalizedName,
                BirthDate = author.BirthDate
            };

            await Context.Authors.AddAsync(authorEntity);
            await Context.SaveChangesAsync();
        }
    }
}
