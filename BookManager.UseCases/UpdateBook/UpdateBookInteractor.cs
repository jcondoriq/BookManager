using BookManager.BusinessObjects.DTOs.Common;
using BookManager.BusinessObjects.DTOs.UpdateBook;
using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.Cross.Entities.Services;

namespace BookManager.UseCases.UpdateBook
{
    internal class UpdateBookInteractor : IUpdateBookInputPort
    {
        readonly IUpdateBookRepository UpdateBookRepository;
        readonly ValidateService<UpdateBookDto> ValidationService;
        readonly IGetBookByIdRepository GetBookByIdRepository;

        public UpdateBookInteractor(IUpdateBookRepository updateBookRepository,
            ValidateService<UpdateBookDto> validationService,
            IGetBookByIdRepository getBookByIdRepository)
        {
            UpdateBookRepository = updateBookRepository;
            ValidationService = validationService;
            GetBookByIdRepository = getBookByIdRepository;
        }

        public async ValueTask Handle(UpdateBookDto updateBookDto)
        {
            await ValidationService.ExecuteValidationGuard(updateBookDto);

            BookDto FindBook = await GetBookByIdRepository.Get(updateBookDto.Id);

            if (FindBook == null)
            {
                throw new Exception("Book not found");
            }

            FindBook = FindBook with
            {
                Isbn = PatchHelper.SetIfChanged(FindBook.Isbn, updateBookDto.Isbn),
                Title = PatchHelper.SetIfChanged(FindBook.Title, updateBookDto.Title),
                CoverUrl = PatchHelper.SetIfChanged(FindBook.CoverUrl, updateBookDto.CoverUrl),
                PublicationYear = PatchHelper.SetIfChanged(FindBook.PublicationYear, updateBookDto.PublicationYear),
                PageNumber = PatchHelper.SetIfChanged(FindBook.PageNumber, updateBookDto.PageNumber),
                AuthorId = PatchHelper.SetIfChanged(FindBook.AuthorId, updateBookDto.AuthorId)
            };

            await UpdateBookRepository.Update(FindBook);
        }
    }
}
