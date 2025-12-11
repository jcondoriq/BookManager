using BookManager.BusinessObjects.DTOs.GetPagedBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Controllers
{
    public interface IGetPagedBooksController
    {
        ValueTask<GetPagedBooksResponseDto> GetPagedAsync(GetPagedBooksRequestDto requestDto);
    }
}
