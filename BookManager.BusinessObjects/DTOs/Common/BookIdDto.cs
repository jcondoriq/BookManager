using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.DTOs.Common
{
    public record struct BookIdDto(
        Guid BookId
        );
}
