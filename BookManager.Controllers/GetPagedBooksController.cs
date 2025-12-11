using BookManager.BusinessObjects.DTOs.GetPagedBooks;
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
    internal class GetPagedBooksController : IGetPagedBooksController
    {
        readonly IGetPagedBooksInputPort GetPagedBooksInputPort;
        readonly IGetPagedBooksPresenter GetPagedBooksPresenter;

        public GetPagedBooksController(IGetPagedBooksInputPort getPagedBooksInputPort, 
            IGetPagedBooksPresenter getPagedBooksPresenter)
        {
            GetPagedBooksInputPort = getPagedBooksInputPort;
            GetPagedBooksPresenter = getPagedBooksPresenter;
        }

        public async ValueTask<GetPagedBooksResponseDto> GetPagedAsync(GetPagedBooksRequestDto requestDto)
        {
            await GetPagedBooksInputPort.Handle(requestDto);
            return GetPagedBooksPresenter.GetPagedBooksResponse;
        }
    }
}
