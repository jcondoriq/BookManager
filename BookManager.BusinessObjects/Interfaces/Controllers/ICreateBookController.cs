using BookManager.BusinessObjects.DTOs.CreateBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Controllers
{
    public interface ICreateBookController
    {
        ValueTask<Guid> CreateAsync(CreateBookDto createBookDto);
    }
}
