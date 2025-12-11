using BookManager.BusinessObjects.DTOs.GetPagedAuthors;
using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.Cross.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.UseCases.GetPagedAuthors
{
    internal class GetPagedAuthorsInteractor : IGetPagedAuthorsInputPort
    {
        readonly IGetPagedAuthorsOutputPort GetPagedAuthorsOutputPort;
        readonly IGetPagedAuthorsRepository GetPagedAuthorsRepository;
        readonly ValidateService<GetPagedAuthorsRequestDto> ValidationService;

        public GetPagedAuthorsInteractor(IGetPagedAuthorsOutputPort getPagedAuthorsOutputPort, 
            IGetPagedAuthorsRepository getPagedAuthorsRepository, 
            ValidateService<GetPagedAuthorsRequestDto> validationService)
        {
            GetPagedAuthorsOutputPort = getPagedAuthorsOutputPort;
            GetPagedAuthorsRepository = getPagedAuthorsRepository;
            ValidationService = validationService;
        }

        public async ValueTask Handle(GetPagedAuthorsRequestDto getPagedAuthorsRequestDto)
        {
            await ValidationService.ExecuteValidationGuard(getPagedAuthorsRequestDto);

            var (books, totalItems) = await GetPagedAuthorsRepository.GetPagedAsync(getPagedAuthorsRequestDto.Page, 
                                                                                    getPagedAuthorsRequestDto.PageSize);

            int totalPages = (int)Math.Ceiling(totalItems / (double)getPagedAuthorsRequestDto.PageSize);

            GetPagedAuthorsResponseDto Response = new(totalItems, totalPages, books);

            await GetPagedAuthorsOutputPort.Handle(Response);
        }
    }
}
