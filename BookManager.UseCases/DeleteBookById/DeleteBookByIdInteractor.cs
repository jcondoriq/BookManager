using BookManager.BusinessObjects.DTOs.Common;
using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.Cross.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.UseCases.DeleteBookById
{
    internal class DeleteBookByIdInteractor : IDeleteBookByIdInputPort
    {
        readonly IDeleteBookByIdRepository DeleteBookByIdRepository;
        readonly ValidateService<BookIdDto> ValidationService;

        public DeleteBookByIdInteractor(IDeleteBookByIdRepository deleteBookByIdRepository, 
            ValidateService<BookIdDto> validationService)
        {
            DeleteBookByIdRepository = deleteBookByIdRepository;
            ValidationService = validationService;
        }

        public async ValueTask Handle(BookIdDto bookIdDto)
        {
            await ValidationService.ExecuteValidationGuard(bookIdDto);

            await DeleteBookByIdRepository.Delete(bookIdDto.BookId);
        }
    }
}
