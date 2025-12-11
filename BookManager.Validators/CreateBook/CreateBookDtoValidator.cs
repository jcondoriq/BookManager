using BookManager.BusinessObjects.DTOs.CreateAutor;
using BookManager.BusinessObjects.DTOs.CreateBook;
using BookManager.Validators.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Validators.CreateBook
{
    internal class CreateBookDtoValidator :
        ValidatorWrapper<CreateBookDto>
    {
        public CreateBookDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Book title must be provided.")
                .MaximumLength(200)
                .WithMessage("Book title must not exceed 200 characters.");

            RuleFor(x => x.Isbn)
                .NotEmpty()
                .WithMessage("ISBN must be provided.")
                .MaximumLength(20)
                .WithMessage("ISBN must not exceed 20 characters.");

            RuleFor(x => x.PublicationYear)
                .InclusiveBetween(1450, DateTime.Now.Year)
                .WithMessage("Publication year must be between 1450 and the current year.");

            RuleFor(x => x.PageNumber)
                .GreaterThan(0)
                .WithMessage("Page number must be greater than zero.");

            RuleFor(x => x.AuthorId)
                .NotEmpty()
                .WithMessage("Author ID must be provided.");
        }
    }
}
