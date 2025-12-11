using BookManager.BusinessObjects.DTOs.GetPagedAuthors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Controllers
{
    public interface IGetPagedAuthorsController
    {
        ValueTask<GetPagedAuthorsResponseDto> GetPagedAsync(GetPagedAuthorsRequestDto getPagedAuthorsRequestDto);
    }
}
