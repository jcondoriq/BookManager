using BookManager.BusinessObjects.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Repositories
{
    public interface ICreateAuthorRepository
    {
        ValueTask CreateAuthorAsync(Author author);
    }
}
