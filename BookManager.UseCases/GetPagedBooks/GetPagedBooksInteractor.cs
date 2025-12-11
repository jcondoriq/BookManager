using BookManager.BusinessObjects.DTOs.GetPagedBooks;
using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.Cross.Entities.Interfaces;
using BookManager.Cross.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.UseCases.GetPagedBooks
{
    internal class GetPagedBooksInteractor : IGetPagedBooksInputPort
    {
        readonly IGetPagedBooksOutputPort OutputPort;
        readonly IGetPagedBooksRepository Repository;
        readonly ValidateService<GetPagedBooksRequestDto> ValidationService;
        readonly IStringNormalizer Normalizer;

        public GetPagedBooksInteractor(IGetPagedBooksOutputPort outputPort, 
            IGetPagedBooksRepository repository,
            ValidateService<GetPagedBooksRequestDto> validationService,
            IStringNormalizer normalizer)
        {
            OutputPort = outputPort;
            Repository = repository;
            ValidationService = validationService;
            Normalizer = normalizer;
        }

        public async ValueTask Handle(GetPagedBooksRequestDto getPagedBooksRequestDto)
        {
            await ValidationService.ExecuteValidationGuard(getPagedBooksRequestDto);

            string? NormalizedSearch = null;

            if (!string.IsNullOrWhiteSpace(getPagedBooksRequestDto.Search))
                NormalizedSearch = Normalizer.Normalize(getPagedBooksRequestDto.Search);

            var (books, totalItems) = await Repository.GetPagedAsync(
                NormalizedSearch, getPagedBooksRequestDto.Page, getPagedBooksRequestDto.PageSize);

            int totalPages = (int)Math.Ceiling(totalItems / (double)getPagedBooksRequestDto.PageSize);

            GetPagedBooksResponseDto Response = new( totalItems, totalPages, books);

            await OutputPort.Handle(Response);
        }
    }
}
