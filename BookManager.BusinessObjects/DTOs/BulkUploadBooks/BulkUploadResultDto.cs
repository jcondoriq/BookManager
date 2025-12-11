using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BusinessObjects.DTOs.BulkUploadBooks
{
    public record struct BulkUploadResultDto(
        int TotalRows,
        int SuccessCount,
        int ErrorCount,
        IEnumerable<BulkUploadErrorDto> Errors
        );
}
