using BookManager.BusinessObjects.DTOs.BulkUploadBooks;
using BookManager.BusinessObjects.Interfaces.Controllers;
using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Presenters;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Controllers
{
    internal class BulkUploadBooksController : IBulkUploadBooksController
    {
        readonly IBulkUploadBooksInputPort InputPort;
        readonly IBulkUploadBooksPresenter Presenter;

        public BulkUploadBooksController(IBulkUploadBooksInputPort inputPort, 
            IBulkUploadBooksPresenter presenter)
        {
            InputPort = inputPort;
            Presenter = presenter;
        }

        public async ValueTask<BulkUploadResultDto> BulkUploadBooksAsync(BulkUploadBooksRequestDto file)
        {
            await InputPort.Handle(file);
            return Presenter.BulkUploadResultDto;
        }
    }
}
