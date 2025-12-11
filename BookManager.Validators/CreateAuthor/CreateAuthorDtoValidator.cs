using BookManager.BusinessObjects.DTOs.CreateAutor;
using BookManager.Validators.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Validators.CreateAuthor
{
    internal class CreateAuthorDtoValidator :
        ValidatorWrapper<CreateAuthorDto>
    {
        public CreateAuthorDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Author name must be provided.")
                .MaximumLength(100)
                .WithMessage("Author name must not exceed 100 characters.");
            RuleFor(x => x.BirthDate)
                .LessThan(DateTime.Now)
                .WithMessage("Birth date must be in the past.");
        }

    }
}
