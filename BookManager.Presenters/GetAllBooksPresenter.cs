using BookManager.BusinessObjects.DTOs.Common;
using BookManager.BusinessObjects.Interfaces.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Presenters
{
    internal class GetAllBooksPresenter : IGetAllBooksPresenter
    {
        public List<BookDto> Books { get; private set; }

        public ValueTask Handle(List<BookDto> books)
        {
            Books = books;
            return ValueTask.CompletedTask;
        }
    }
}
