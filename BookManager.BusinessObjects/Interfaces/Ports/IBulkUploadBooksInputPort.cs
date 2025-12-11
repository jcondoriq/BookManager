using BookManager.BusinessObjects.DTOs.BulkUploadBooks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Ports
{
    public interface IBulkUploadBooksInputPort
    {
        ValueTask Handle(BulkUploadBooksRequestDto fileDto);
    }
}
