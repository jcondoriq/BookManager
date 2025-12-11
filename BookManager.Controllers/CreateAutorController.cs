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
    internal class CreateAutorController : ICreateAutorController
    {
        readonly ICreateAutorInputPort InputPort;
        readonly ICreateAutorPresenter Presenter;

        public CreateAutorController(ICreateAutorInputPort inputPort, ICreateAutorPresenter presenter)
        {
            InputPort = inputPort;
            Presenter = presenter;
        }

        public async ValueTask<Guid> CreateAutor(CreateAuthorDto createAuthorDto)
        {
            await InputPort.Handle(createAuthorDto);

            return Presenter.AuthorId;
        }
    }
}
