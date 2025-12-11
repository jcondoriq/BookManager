using BookManager.BusinessObjects.DTOs.DeleteAuthorById;
using BookManager.BusinessObjects.Interfaces.Controllers;
using BookManager.BusinessObjects.Interfaces.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Controllers
{
    internal class DeleteAuthorByIdController : IDeleteAuthorByIdController
    {
        readonly IDeleteAuthorByIdInputPort DeleteAuthorByIdInputPort;

        public DeleteAuthorByIdController(IDeleteAuthorByIdInputPort deleteAuthorByIdInputPort)
        {
            DeleteAuthorByIdInputPort = deleteAuthorByIdInputPort;
        }

        public async ValueTask DeleteAuthorById(DeleteAuthorByIdDto authorId)
        {
            await DeleteAuthorByIdInputPort.Handle(authorId);
        }
    }
}
