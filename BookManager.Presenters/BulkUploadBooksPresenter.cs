using BookManager.BusinessObjects.DTOs.BulkUploadBooks;
using BookManager.BusinessObjects.Interfaces.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Presenters
{
    internal class BulkUploadBooksPresenter : IBulkUploadBooksPresenter
    {
        public BulkUploadResultDto BulkUploadResultDto { get; private set; }

        public ValueTask Handle(BulkUploadResultDto bulkUploadResultDto)
        {
            BulkUploadResultDto = bulkUploadResultDto;
            return ValueTask.CompletedTask;
        }
    }
}
