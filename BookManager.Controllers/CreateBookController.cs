using BookManager.BusinessObjects.DTOs.CreateBook;
using BookManager.BusinessObjects.Interfaces.Controllers;
using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Controllers
{
    internal class CreateBookController : ICreateBookController
    {
        readonly ICreateBookInputPort InputPort;
        readonly ICreateBookPresenter Presenter;

        public CreateBookController(ICreateBookInputPort inputPort, 
            ICreateBookPresenter presenter)
        {
            InputPort = inputPort;
            Presenter = presenter;
        }

        public async ValueTask<Guid> CreateAsync(CreateBookDto createBookDto)
        {
            await InputPort.Handle(createBookDto);
            return Presenter.BookId;
        }
    }
}
