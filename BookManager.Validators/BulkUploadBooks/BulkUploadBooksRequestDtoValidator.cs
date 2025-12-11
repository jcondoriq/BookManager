using BookManager.BusinessObjects.DTOs.BulkUploadBooks;
using BookManager.Validators.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Validators.BulkUploadBooks
{
    internal class BulkUploadBooksRequestDtoValidator :
        ValidatorWrapper<BulkUploadBooksRequestDto>
    {
        public BulkUploadBooksRequestDtoValidator()
        {
            RuleFor(x => x.File)
                .NotNull().WithMessage("El archivo CSV es obligatorio.")
                .Must(f => f != null && f.Length > 0).WithMessage("El archivo CSV no puede estar vacío.")
                .Must(f => f.ContentType == "text/csv"
                           || f.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Solo se permiten archivos CSV.");
        }
    }
}
