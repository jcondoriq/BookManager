using BookManager.BusinessObjects.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Controllers
{
    public interface IGetAllBooksController
    {
        ValueTask<List<BookDto>> GetAll();
    }
}
