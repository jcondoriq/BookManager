using BookManager.BusinessObjects.DTOs.Common;
using BookManager.BusinessObjects.DTOs.CreateBook;
using BookManager.BusinessObjects.Interfaces.ExternalServices;
using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.BusinessObjects.POCOEntities;
using BookManager.Cross.Entities.Interfaces;
using BookManager.Cross.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.UseCases.CreateBook
{
    internal class CreateBookInteractor : ICreateBookInputPort
    {
        readonly ICreateBookOutputPort OutputPort;
        readonly ICreateBookRepository Repository;
        readonly IValidateIsbnExternalService ValidateIsbn;
        readonly IGetCoverUrlByIsbnExternalService GetCoverUrlByIsbn;
        readonly ValidateService<CreateBookDto> ValidationService;
        readonly IStringNormalizer Normalizer;

        public CreateBookInteractor(ICreateBookOutputPort outputPort, 
            ICreateBookRepository repository, 
            IValidateIsbnExternalService validateIsbn,
            IGetCoverUrlByIsbnExternalService getCoverUrlByIsbn,
            ValidateService<CreateBookDto> validationService,
            IStringNormalizer normalizer)
        {
            OutputPort = outputPort;
            Repository = repository;
            ValidateIsbn = validateIsbn;
            GetCoverUrlByIsbn = getCoverUrlByIsbn;
            ValidationService = validationService;
            Normalizer = normalizer;
        }

        public async ValueTask Handle(CreateBookDto bookDto)
        {
            await ValidationService.ExecuteValidationGuard(bookDto);

            if(!await ValidateIsbn.ValidateIsbn(bookDto.Isbn))
            {
                throw new ArgumentException("The provided ISBN is not valid.");
            }

            string CoverUrl = await GetCoverUrlByIsbn.GetCoverUrlByIsbn(bookDto.Isbn);

            Book NewBook = new()
            {
                Id = Guid.NewGuid(),
                CoverUrl = CoverUrl,
                Isbn = bookDto.Isbn,
                PublicationYear = bookDto.PublicationYear,
                Title = bookDto.Title,
                NormalizedTitle = Normalizer.Normalize(bookDto.Title),
                PageNumber = bookDto.PageNumber,
                AuthorId = bookDto.AuthorId
            };

            await Repository.Create(NewBook);

            await OutputPort.Handle(NewBook.Id);
        }
    }
}
