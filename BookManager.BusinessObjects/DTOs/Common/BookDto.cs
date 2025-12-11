using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.DTOs.Common
{
   public record struct BookDto(
         Guid Id,      
         string Isbn,         
         string Title,         
         string CoverUrl,         
         int PublicationYear,
         int PageNumber,         
         Guid AuthorId
        );
}
