using BookManager.BusinessObjects.Interfaces.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Presenters
{
    internal class CreateAutorPresenter : ICreateAutorPresenter
    {
        public Guid AuthorId { get; private set; }

        public ValueTask Handle(Guid authorId)
        {
            AuthorId = authorId;
            return ValueTask.CompletedTask;
        }
    }
}
