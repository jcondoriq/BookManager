using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Repositories
{
    public interface IDeleteBookByIdRepository
    {
        ValueTask Delete(Guid bookId);
    }
}
