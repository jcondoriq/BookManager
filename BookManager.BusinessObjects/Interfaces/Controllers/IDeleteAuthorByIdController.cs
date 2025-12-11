using BookManager.BusinessObjects.DTOs.DeleteAuthorById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Controllers
{
    public interface IDeleteAuthorByIdController
    {
        ValueTask DeleteAuthorById(DeleteAuthorByIdDto authorId);
    }
}
