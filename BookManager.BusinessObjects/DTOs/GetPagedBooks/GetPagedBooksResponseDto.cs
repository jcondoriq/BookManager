using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.DTOs.GetPagedBooks
{
    public record struct GetPagedBooksResponseDto(
        int TotalItems,
        int TotalPages,
        IEnumerable<BookItemDto> Items
        );
}
