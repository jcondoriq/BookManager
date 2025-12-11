using BookManager.BusinessObjects.DTOs.GetPagedBooks;
using BookManager.BusinessObjects.Interfaces.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Presenters
{
    public interface IGetPagedBooksPresenter: IGetPagedBooksOutputPort
    {
        GetPagedBooksResponseDto GetPagedBooksResponse { get; }
    }
}
