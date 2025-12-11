using BookManager.BusinessObjects.DTOs.CreateAutor;
using BookManager.BusinessObjects.DTOs.DeleteAuthorById;
using BookManager.Validators.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Validators.DeleteAuthorById
{
    internal class DeleteAuthorByIdValidator :
        ValidatorWrapper<DeleteAuthorByIdDto>
    {
        public DeleteAuthorByIdValidator()
        {
            RuleFor(x => x.authorId)
                .NotEmpty()
                .WithMessage("Author name must be provided.");
        }
    }
}
