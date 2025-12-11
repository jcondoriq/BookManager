using BookManager.BusinessObjects.DTOs.CreateBook;
using BookManager.BusinessObjects.Interfaces.ExternalServices;
using BookManager.BusinessObjects.Interfaces.Ports;
using BookManager.BusinessObjects.Interfaces.Repositories;
using BookManager.BusinessObjects.POCOEntities;
using BookManager.Cross.Entities.Interfaces;
using BookManager.Cross.Entities.Services;
using BookManager.UseCases.CreateBook;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookManager.UseCases.Tests.CreateBook
{
    public class CreateBookInteractorTests
    {
        [Fact]
        public async Task Handle_Should_Create_Book_Successfully()
        {
            // Arrange
            var outputPort = new Mock<ICreateBookOutputPort>();
            var repo = new Mock<ICreateBookRepository>();
            var isbnValidator = new Mock<IValidateIsbnExternalService>();
            var coverProvider = new Mock<IGetCoverUrlByIsbnExternalService>();
            var normalizer = new Mock<IStringNormalizer>();

            var validators = new List<IValidator<CreateBookDto>>
                                {
                                    new AlwaysValidValidator<CreateBookDto>()
                                };
            var validator = new ValidateService<CreateBookDto>(validators);

            var dto = new CreateBookDto
            {
                Isbn = "9781234567897",
                Title = "Clean Code",
                PublicationYear = 2008,
                PageNumber = 450,
                AuthorId = Guid.NewGuid()
            };

            isbnValidator.Setup(v => v.ValidateIsbn(dto.Isbn))
                         .ReturnsAsync(true);

            coverProvider.Setup(c => c.GetCoverUrlByIsbn(dto.Isbn))
                         .ReturnsAsync("http://covers.com/cc.jpg");

            normalizer.Setup(n => n.Normalize("Clean Code"))
                      .Returns("cleancode");

            repo.Setup(r => r.Create(It.IsAny<Book>()))
                .Returns(ValueTask.CompletedTask);

            var interactor = new CreateBookInteractor(
                outputPort.Object,
                repo.Object,
                isbnValidator.Object,
                coverProvider.Object,
                validator,
                normalizer.Object
            );

            // Act
            await interactor.Handle(dto);

            // Assert
            repo.Verify(r => r.Create(It.Is<Book>(b =>
                b.Isbn == dto.Isbn &&
                b.NormalizedTitle == "cleancode" &&
                b.CoverUrl == "http://covers.com/cc.jpg"
            )), Times.Once);

            outputPort.Verify(o => o.Handle(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Throw_When_Isbn_Invalid()
        {
            // Arrange
            var outputPort = new Mock<ICreateBookOutputPort>();
            var repo = new Mock<ICreateBookRepository>();
            var isbnValidator = new Mock<IValidateIsbnExternalService>();
            var coverProvider = new Mock<IGetCoverUrlByIsbnExternalService>();
            var normalizer = new Mock<IStringNormalizer>();

            var validators = new List<IValidator<CreateBookDto>>
                                {
                                    new AlwaysValidValidator<CreateBookDto>()
                                };
            var validator = new ValidateService<CreateBookDto>(validators);

            var dto = new CreateBookDto { Isbn = "000" };

            isbnValidator.Setup(v => v.ValidateIsbn(dto.Isbn))
                         .ReturnsAsync(false);

            var interactor = new CreateBookInteractor(
                outputPort.Object,
                repo.Object,
                isbnValidator.Object,
                coverProvider.Object,
                validator,
                normalizer.Object
            );

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () => await interactor.Handle(dto));

            repo.Verify(r => r.Create(It.IsAny<Book>()), Times.Never);
            outputPort.Verify(o => o.Handle(It.IsAny<Guid>()), Times.Never);
        }

        [Fact]
        public async Task Handle_Should_Call_Normalizer()
        {
            // Arrange
            var outputPort = new Mock<ICreateBookOutputPort>();
            var repo = new Mock<ICreateBookRepository>();
            var isbnValidator = new Mock<IValidateIsbnExternalService>();
            var coverProvider = new Mock<IGetCoverUrlByIsbnExternalService>();
            var normalizer = new Mock<IStringNormalizer>();

            var validators = new List<IValidator<CreateBookDto>>
                                {
                                    new AlwaysValidValidator<CreateBookDto>()
                                };
            var validator = new ValidateService<CreateBookDto>(validators);

            var dto = new CreateBookDto
            {
                Isbn = "9781234567897",
                Title = " Clean! Code ",
                PublicationYear = 2008,
                PageNumber = 400,
                AuthorId = Guid.NewGuid()
            };

            isbnValidator.Setup(v => v.ValidateIsbn(dto.Isbn))
                         .ReturnsAsync(true);

            coverProvider.Setup(c => c.GetCoverUrlByIsbn(dto.Isbn))
                         .ReturnsAsync("url");

            normalizer.Setup(n => n.Normalize(It.IsAny<string>()))
                      .Returns("cleancode");

            var interactor = new CreateBookInteractor(
                outputPort.Object,
                repo.Object,
                isbnValidator.Object,
                coverProvider.Object,
                validator,
                normalizer.Object
            );

            // Act
            await interactor.Handle(dto);

            // Assert
            normalizer.Verify(n => n.Normalize(" Clean! Code "), Times.Once);
        }
    }
}
