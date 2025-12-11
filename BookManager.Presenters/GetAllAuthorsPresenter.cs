using BookManager.BusinessObjects.DTOs.Common;
using BookManager.BusinessObjects.Interfaces.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Presenters
{
    internal class GetAllAuthorsPresenter : IGetAllAuthorsPresenter
    {
        public List<AuthorDto> Authors { get; private set; } = new List<AuthorDto>();

        public ValueTask Handle(List<AuthorDto> authorDtos)
        {
            Authors = authorDtos;
            return ValueTask.CompletedTask;
        }
    }
}
