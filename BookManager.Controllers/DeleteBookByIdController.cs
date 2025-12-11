using BookManager.BusinessObjects.DTOs.Common;
using BookManager.BusinessObjects.Interfaces.Controllers;
using BookManager.BusinessObjects.Interfaces.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Controllers
{
    internal class DeleteBookByIdController : IDeleteBookByIdController
    {
        readonly IDeleteBookByIdInputPort InputPort;

        public DeleteBookByIdController(IDeleteBookByIdInputPort inputPort)
        {
            InputPort = inputPort;
        }

        public async ValueTask Delete(BookIdDto bookId)
        {
            await InputPort.Handle(bookId);
        }
    }
}
