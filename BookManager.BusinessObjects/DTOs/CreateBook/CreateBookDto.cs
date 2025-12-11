using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.DTOs.CreateBook
{
    public record struct CreateBookDto(
         string Isbn,
         string Title,
         int PublicationYear,
         int PageNumber,
         Guid AuthorId
        );
}
