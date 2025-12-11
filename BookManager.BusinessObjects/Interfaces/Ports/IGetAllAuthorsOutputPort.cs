using BookManager.BusinessObjects.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Ports
{
    public interface IGetAllAuthorsOutputPort
    {
        ValueTask Handle(List<AuthorDto> authors);
    }
}
