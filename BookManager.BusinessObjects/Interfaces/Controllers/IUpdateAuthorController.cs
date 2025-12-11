using BookManager.BusinessObjects.DTOs.UpdateAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Controllers
{
    public interface IUpdateAuthorController
    {
        ValueTask Update(UpdateAuthorDto updateAuthorDto);
    }
}
