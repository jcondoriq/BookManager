using BookManager.BusinessObjects.DTOs.UpdateBook;
using BookManager.Validators.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Validators.UpdateBook
{
    internal class UpdateBookDtoValidator :
        ValidatorWrapper<UpdateBookDto>
    {
        public UpdateBookDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Book ID must be provided.");

            RuleFor(x => x.Title)
                .MaximumLength(200)
                .WithMessage("Book title must not exceed 200 characters.")
                .When(x => !string.IsNullOrEmpty(x.Title));

            RuleFor(x => x.Isbn)
                .MaximumLength(20)
                .WithMessage("ISBN must not exceed 20 characters.")
                .When(x => !string.IsNullOrEmpty(x.Isbn));

            RuleFor(x => x.PublicationYear)
                .InclusiveBetween(1450, DateTime.Now.Year)
                .WithMessage("Publication year must be between 1450 and the current year.")
                .When(x => x.PublicationYear > 0);
        }
    }
}
