using BookManager.BusinessObjects.DTOs.UpdateBook;
using BookManager.BusinessObjects.Interfaces.Controllers;
using BookManager.BusinessObjects.Interfaces.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Controllers
{
    internal class UpdateBookController : IUpdateBookController
    {
        readonly IUpdateBookInputPort UpdateBookInputPort;

        public UpdateBookController(IUpdateBookInputPort updateBookInputPort)
        {
            UpdateBookInputPort = updateBookInputPort;
        }

        public async ValueTask Update(UpdateBookDto updateBookDto)
        {
            await UpdateBookInputPort.Handle(updateBookDto);
        }
    }
}
