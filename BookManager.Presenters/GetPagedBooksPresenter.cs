using BookManager.BusinessObjects.DTOs.GetPagedBooks;
using BookManager.BusinessObjects.Interfaces.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Presenters
{
    internal class GetPagedBooksPresenter : IGetPagedBooksPresenter
    {
        public GetPagedBooksResponseDto GetPagedBooksResponse { get; private set; }

        public ValueTask Handle(GetPagedBooksResponseDto getPagedBooksResponseDto)
        {
            GetPagedBooksResponse = getPagedBooksResponseDto;

            return ValueTask.CompletedTask;
        }
    }
}
