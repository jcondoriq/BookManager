using BookManager.BusinessObjects.DTOs.DeleteAuthorById;
using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.Cross.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.UseCases.DeleteAuthorById
{
    internal class DeleteAuthorByIdInteractor : IDeleteAuthorByIdInputPort
    {
        readonly IDeleteAuthorByIdRepository DeleteAuthorByIdRepository;
        readonly ValidateService<DeleteAuthorByIdDto> ValidationService;

        public DeleteAuthorByIdInteractor(IDeleteAuthorByIdRepository deleteAuthorByIdRepository, 
            ValidateService<DeleteAuthorByIdDto> validationService)
        {
            DeleteAuthorByIdRepository = deleteAuthorByIdRepository;
            ValidationService = validationService;
        }

        public async ValueTask Handle(DeleteAuthorByIdDto dto)
        {
            await ValidationService.ExecuteValidationGuard(dto);

            await DeleteAuthorByIdRepository.DeleteById(dto.authorId);
        }
    }
}
