using BookManager.BusinessObjects.DTOs.Common;
using BookManager.BusinessObjects.DTOs.CreateAutor;
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
    internal class GetAllAuthorsController: IGetAllAuthorsController
    {
        readonly IGetAllAuthorInputPort InputPort;
        readonly IGetAllAuthorsPresenter Presenter;

        public GetAllAuthorsController(IGetAllAuthorInputPort inputPort, IGetAllAuthorsPresenter presenter)
        {
            InputPort = inputPort;
            Presenter = presenter;
        }

        public async ValueTask<List<AuthorDto>> GetAllAuthors()
        {
            await InputPort.Handle();

            return Presenter.Authors;
        }
    }
}
