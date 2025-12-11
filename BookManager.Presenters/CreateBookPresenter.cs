using BookManager.BusinessObjects.Interfaces.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Presenters
{
    internal class CreateBookPresenter : ICreateBookPresenter
    {
        public Guid BookId { get; private set; }

        public ValueTask Handle(Guid bookId)
        {
            BookId = bookId;
            return ValueTask.CompletedTask;
        }
    }
}
