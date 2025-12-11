using BookManager.BusinessObjects.DTOs.CreateAutor;
using BookManager.BusinessObjects.DTOs.UpdateAuthor;
using BookManager.Validators.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Validators.UpdateAuthor
{
    internal class UpdateAuthorValidator :
        ValidatorWrapper<UpdateAuthorDto>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Author ID must be provided.");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Author name must not exceed 100 characters.")
                .When(x => !string.IsNullOrEmpty(x.Name));
            
            RuleFor(x => x.BirthDate)
                .LessThan(DateTime.Now)
                .WithMessage("Birth date must be in the past.")
                .When(x => x.BirthDate.HasValue);
        }
    }
}
