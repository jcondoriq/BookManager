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
    internal class GetAllBooksController : IGetAllBooksController
    {
        readonly IGetAllBooksInputPort InputPort;
        readonly IGetAllBooksPresenter Presenter;

        public GetAllBooksController(IGetAllBooksInputPort inputPort, 
            IGetAllBooksPresenter presenter)
        {
            InputPort = inputPort;
            Presenter = presenter;
        }

        public async ValueTask<List<BookDto>> GetAll()
        {
            await InputPort.Handle();

            return Presenter.Books;
        }
    }
}
