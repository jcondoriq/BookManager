using BookManager.BusinessObjects.DTOs.GetPagedBooks;
using BookManager.Validators.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Validators.GetPagedBooks
{
    internal class GetPagedBooksRequestDtoValidator :
        ValidatorWrapper<GetPagedBooksRequestDto>
    {
        public GetPagedBooksRequestDtoValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Page number must be greater than zero.");
            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100)
                .WithMessage("Page size must be between 1 and 100.");
        }
    }
}
