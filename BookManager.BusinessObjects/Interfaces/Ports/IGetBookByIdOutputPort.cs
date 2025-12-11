using BookManager.BusinessObjects.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Ports
{
    public interface IGetBookByIdOutputPort
    {
        ValueTask Handle(BookDto book);
    }
}
