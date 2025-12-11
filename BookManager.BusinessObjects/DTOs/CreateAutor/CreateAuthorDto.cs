using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.DTOs.CreateAutor
{
    public record struct CreateAuthorDto(
        string Name,
        DateTime BirthDate
        );
}
