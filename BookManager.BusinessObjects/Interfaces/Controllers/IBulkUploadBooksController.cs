using BookManager.BusinessObjects.DTOs.BulkUploadBooks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.Interfaces.Controllers
{
    public interface IBulkUploadBooksController
    {
        ValueTask<BulkUploadResultDto> BulkUploadBooksAsync(BulkUploadBooksRequestDto file);
    }
}
