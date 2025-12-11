using BookManager.BusinessObjects.DTOs.GetPagedAuthors;
using BookManager.BusinessObjects.Interfaces.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Presenters
{
    public interface IGetPagedAuthorsPresenter: IGetPagedAuthorsOutputPort
    {
        GetPagedAuthorsResponseDto GetPagedAuthorsResponseDto { get; }
    }
}
