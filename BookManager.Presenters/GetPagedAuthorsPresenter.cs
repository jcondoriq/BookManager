using BookManager.BusinessObjects.DTOs.GetPagedAuthors;
using BookManager.BusinessObjects.Interfaces.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Presenters
{
    internal class GetPagedAuthorsPresenter : IGetPagedAuthorsPresenter
    {
        public GetPagedAuthorsResponseDto GetPagedAuthorsResponseDto { get; private set; }

        public ValueTask Handle(GetPagedAuthorsResponseDto getPagedAuthorsResponseDto)
        {
            GetPagedAuthorsResponseDto = getPagedAuthorsResponseDto;
            return ValueTask.CompletedTask;
        }
    }
}
