using BookManager.BusinessObjects.DTOs.GetPagedAuthors;
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
    internal class GetPagedAuthorsController : IGetPagedAuthorsController
    {
        readonly IGetPagedAuthorsInputPort GetPagedAuthorsInputPort;
        readonly IGetPagedAuthorsPresenter GetPagedAuthorsPresenter;
        public GetPagedAuthorsController(
            IGetPagedAuthorsInputPort getPagedAuthorsInputPort,
            IGetPagedAuthorsPresenter getPagedAuthorsPresenter)
        {
            GetPagedAuthorsInputPort = getPagedAuthorsInputPort;
            GetPagedAuthorsPresenter = getPagedAuthorsPresenter;
        }
        public async ValueTask<GetPagedAuthorsResponseDto> GetPagedAsync(GetPagedAuthorsRequestDto getPagedAuthorsRequestDto)
        {
            await GetPagedAuthorsInputPort.Handle(getPagedAuthorsRequestDto);
            return GetPagedAuthorsPresenter.GetPagedAuthorsResponseDto;
        }
    }
}
