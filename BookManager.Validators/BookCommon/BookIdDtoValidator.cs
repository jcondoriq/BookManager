using BookManager.BusinessObjects.DTOs.Common;
using BookManager.Validators.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Validators.BookCommon
{
    internal class BookIdDtoValidator :
        ValidatorWrapper<BookIdDto>
    {
        public BookIdDtoValidator()
        {
            RuleFor(x => x.BookId)
                .NotEmpty()
                .WithMessage("Book ID must be provided.");
        }
    }
}
