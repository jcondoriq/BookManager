using BookManager.Api.Controllers;
using BookManager.BusinessObjects.DTOs.CreateBook;
using BookManager.BusinessObjects.Interfaces.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookManager.Api.Tests.Controllers
{
    public class BooksController_Post_Tests
    {
        private readonly Mock<ICreateBookController> _createBookControllerMock;
        private readonly BooksController _controller;

        public BooksController_Post_Tests()
        {
            _createBookControllerMock = new Mock<ICreateBookController>();

            // Para este test solo necesitamos CreateBookController
            _controller = new BooksController(
                _createBookControllerMock.Object,
                Mock.Of<IGetAllBooksController>(),
                Mock.Of<IGetBookByIdController>(),
                Mock.Of<IDeleteBookByIdController>(),
                Mock.Of<IUpdateBookController>(),
                Mock.Of<IGetPagedBooksController>(),
                Mock.Of<IBulkUploadBooksController>()
            );
        }

        [Fact]
        public async Task Post_ShouldReturnOk_WithBookId()
        {
            // Arrange
            var expectedId = Guid.NewGuid();

            _createBookControllerMock
                .Setup(s => s.CreateAsync(It.IsAny<CreateBookDto>()))
                .ReturnsAsync(expectedId);

            var dto = new CreateBookDto(
                Isbn: "9783161484100",
                Title: "Clean Code",
                PublicationYear: 2008,
                PageNumber: 464,
                AuthorId: Guid.NewGuid()
            );

            // Act
            var result = await _controller.Post(dto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            var value = okResult.Value!;
            var propInfo = value.GetType().GetProperty("BookId")!;
            var returnedId = (Guid)propInfo.GetValue(value)!;

            Assert.Equal(expectedId, returnedId);

            // Verificar que CreateAsync fue llamado una vez con el DTO correcto
            _createBookControllerMock.Verify(
                s => s.CreateAsync(It.Is<CreateBookDto>(b =>
                    b.Isbn == dto.Isbn &&
                    b.Title == dto.Title &&
                    b.PublicationYear == dto.PublicationYear &&
                    b.PageNumber == dto.PageNumber &&
                    b.AuthorId == dto.AuthorId
                )),
                Times.Once
            );
        }
    }
}
