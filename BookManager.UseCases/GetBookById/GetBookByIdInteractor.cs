using BookManager.BusinessObjects.DTOs.Common;
using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.Cross.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.UseCases.GetBookById
{
    internal class GetBookByIdInteractor : IGetBookByIdInputPort
    {
        readonly IGetBookByIdOutputPort GetBookByIdOutputPort;
        readonly IGetBookByIdRepository GetBookByIdRepository;
        readonly ValidateService<BookIdDto> ValidationService;

        public GetBookByIdInteractor(IGetBookByIdOutputPort getBookByIdOutputPort, 
            IGetBookByIdRepository getBookByIdRepository,
            ValidateService<BookIdDto> validateService)
        {
            GetBookByIdOutputPort = getBookByIdOutputPort;
            GetBookByIdRepository = getBookByIdRepository;
            ValidationService = validateService;
        }

        public async ValueTask Handle(BookIdDto bookId)
        {
            await ValidationService.ExecuteValidationGuard(bookId);

            BookDto FindBook = await GetBookByIdRepository.Get(bookId.BookId);

            await GetBookByIdOutputPort.Handle(FindBook);
        }
    }
}
