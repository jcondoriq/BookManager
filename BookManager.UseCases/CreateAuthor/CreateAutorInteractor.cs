using BookManager.BusinessObjects.DTOs.CreateAutor;
using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.BusinessObjects.POCOEntities;
using BookManager.Cross.Entities.Interfaces;
using BookManager.Cross.Entities.Services;

namespace BookManager.UseCases.CreateAuthor
{
    internal class CreateAutorInteractor : ICreateAutorInputPort
    {
        readonly ICreateAuthorRepository CreateAuthorRepository;
        readonly ICreateAutorOutputPort CreateAutorOutputPort;
        readonly ValidateService<CreateAuthorDto> ValidationService;
        readonly IStringNormalizer Normalizer;

        public CreateAutorInteractor(ICreateAuthorRepository createAuthorRepository, 
            ICreateAutorOutputPort createAutorOutputPort, 
            ValidateService<CreateAuthorDto> validationService,
            IStringNormalizer normalizer)
        {
            CreateAuthorRepository = createAuthorRepository;
            CreateAutorOutputPort = createAutorOutputPort;
            ValidationService = validationService;
            Normalizer = normalizer;
        }

        public async ValueTask Handle(CreateAuthorDto authorDto)
        {
            await ValidationService.ExecuteValidationGuard(authorDto);

            Author NewAuthor = new()
            {
                Id = Guid.NewGuid(),
                Name = authorDto.Name,
                NormalizedName = Normalizer.Normalize(authorDto.Name),
                BirthDate = authorDto.BirthDate
            };

            await CreateAuthorRepository.CreateAuthorAsync(NewAuthor);

            await CreateAutorOutputPort.Handle(NewAuthor.Id);
        }
    }
}
