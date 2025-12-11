using BookManager.BusinessObjects.DTOs.Common;
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
    internal class GetBookByIdController : IGetBookByIdController
    {
        readonly IGetBookByIdInputPort InputPort;
        readonly IGetBookByIdPresenter Presenter;

        public GetBookByIdController(IGetBookByIdInputPort inputPort, IGetBookByIdPresenter presenter)
        {
            InputPort = inputPort;
            Presenter = presenter;
        }

        public async ValueTask<BookDto> Get(BookIdDto bookId)
        {
            await InputPort.Handle(bookId);
            return Presenter.Book;
        }
    }
}
