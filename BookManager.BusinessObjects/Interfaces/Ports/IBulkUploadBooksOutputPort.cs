using BookManager.BusinessObjects.DTOs.BulkUploadBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Ports
{
    public interface IBulkUploadBooksOutputPort
    {
        ValueTask Handle(BulkUploadResultDto bulkUploadResultDto);  
    }
}
