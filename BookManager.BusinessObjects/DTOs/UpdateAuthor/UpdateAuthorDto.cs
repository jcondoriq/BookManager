using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.DTOs.UpdateAuthor
{
    public record struct UpdateAuthorDto(
        Guid Id,
        string? Name,
        DateTime? BirthDate
        );
}
