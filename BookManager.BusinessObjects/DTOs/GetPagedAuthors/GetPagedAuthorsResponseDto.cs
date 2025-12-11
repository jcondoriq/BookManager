using BookManager.BusinessObjects.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.DTOs.GetPagedAuthors
{
    public record struct GetPagedAuthorsResponseDto(
        int TotalItems,
        int TotalPages,
        IEnumerable<AuthorDto> Items
        );
}
