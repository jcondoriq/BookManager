using BookManager.BusinessObjects.DTOs.BulkUploadBooks;
using BookManager.BusinessObjects.DTOs.Common;
using BookManager.BusinessObjects.DTOs.CreateAutor;
using BookManager.BusinessObjects.DTOs.CreateBook;
using BookManager.BusinessObjects.DTOs.DeleteAuthorById;
using BookManager.BusinessObjects.DTOs.GetPagedBooks;
using BookManager.BusinessObjects.DTOs.UpdateAuthor;
using BookManager.BusinessObjects.DTOs.UpdateBook;
using BookManager.BusinessObjects.Interfaces.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly ICreateBookController CreateBookController;
        readonly IGetAllBooksController GetAllBooksController;
        readonly IGetBookByIdController GetBookByIdController;
        readonly IDeleteBookByIdController DeleteBookByIdController;
        readonly IUpdateBookController UpdateBookController;
        readonly IGetPagedBooksController GetPagedBooksController;
        readonly IBulkUploadBooksController BulkUploadBooksController;

        public BooksController(ICreateBookController createBookController,
            IGetAllBooksController getAllBooksController,
            IGetBookByIdController getBookByIdController,
            IDeleteBookByIdController deleteBookByIdController,
            IUpdateBookController updateBookController,
            IGetPagedBooksController getPagedBooksController,
            IBulkUploadBooksController bulkUploadBooksController)
        {
            CreateBookController = createBookController;
            GetAllBooksController = getAllBooksController;
            GetBookByIdController = getBookByIdController;
            DeleteBookByIdController = deleteBookByIdController;
            UpdateBookController = updateBookController;
            GetPagedBooksController = getPagedBooksController;
            BulkUploadBooksController = bulkUploadBooksController;
        }

        [HttpGet]
        public async ValueTask<IActionResult> Get()
        {
            var Books = await GetAllBooksController.GetAll();
            return Ok(Books);
        }

        [HttpGet("{id:guid}")]
        public async ValueTask<IActionResult> Get(Guid id)
        {
            var Book = await GetBookByIdController.Get(new BookIdDto(id));
            return Ok(Book);
        }

        [HttpPost]
        public async ValueTask<IActionResult> Post(CreateBookDto createBookDto)
        {
            var BookId = await CreateBookController.CreateAsync(createBookDto);
            return Ok(new { BookId = BookId });
        }

        [HttpPatch("{id:guid}")]
        public async ValueTask<IActionResult> Patch(Guid id, UpdateBookRequest updateBookRequest)
        {
            await UpdateBookController.Update(new UpdateBookDto(id,
                                                                updateBookRequest.Isbn,
                                                                updateBookRequest.Title,
                                                                updateBookRequest.CoverUrl,
                                                                updateBookRequest.PublicationYear,
                                                                updateBookRequest.PageNumber,
                                                                updateBookRequest.AuthorId)
                                              );

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async ValueTask<IActionResult> Delete(Guid id)
        {
            await DeleteBookByIdController.Delete(new BookIdDto(id));
            return Ok();
        }

        [HttpGet("GetPage")]
        public async Task<IActionResult> GetPage([FromQuery] GetPagedBooksRequestDto request)
        {
            var response = await GetPagedBooksController.GetPagedAsync(request);
            return Ok(response);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            var result = await BulkUploadBooksController.BulkUploadBooksAsync(new BulkUploadBooksRequestDto(file));

            return Ok(result);
        }

    }
}
