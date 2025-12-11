using BookManager.BusinessObjects.DTOs.CreateAutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Ports
{
    public interface ICreateAutorInputPort
    {
        ValueTask Handle(CreateAuthorDto authorDto);
    }
}
