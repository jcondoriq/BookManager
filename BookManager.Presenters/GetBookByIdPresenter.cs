using BookManager.BusinessObjects.DTOs.Common;
using BookManager.BusinessObjects.Interfaces.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Presenters
{
    internal class GetBookByIdPresenter : IGetBookByIdPresenter
    {
        public BookDto Book { get; private set; }

        public ValueTask Handle(BookDto book)
        {
            Book = book;
            return ValueTask.CompletedTask;
        }
    }
}
