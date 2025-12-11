using BookManager.BusinessObjects.DTOs.CreateAutor;
using BookManager.BusinessObjects.DTOs.DeleteAuthorById;
using BookManager.BusinessObjects.DTOs.GetPagedAuthors;
using BookManager.BusinessObjects.DTOs.GetPagedBooks;
using BookManager.BusinessObjects.DTOs.UpdateAuthor;
using BookManager.BusinessObjects.Interfaces.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookManager.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        readonly ICreateAutorController CreateAutorController;
        readonly IGetAllAuthorsController GetAllAuthorsController;
        readonly IDeleteAuthorByIdController DeleteAuthorByIdController;
        readonly IUpdateAuthorController UpdateAuthorController;
        readonly IGetPagedAuthorsController GetPagedAuthorsController;
        public AuthorsController(ICreateAutorController createAutorController,
            IGetAllAuthorsController getAllAuthorsController,
            IDeleteAuthorByIdController deleteAuthorByIdController,
            IUpdateAuthorController updateAuthorController,
            IGetPagedAuthorsController getPagedAuthorsController)
        {
            CreateAutorController = createAutorController;
            GetAllAuthorsController = getAllAuthorsController;
            DeleteAuthorByIdController = deleteAuthorByIdController;
            UpdateAuthorController = updateAuthorController;
            GetPagedAuthorsController = getPagedAuthorsController;
        }

        [HttpGet]
        public async ValueTask<IActionResult> Get()
        {
            var authors = await GetAllAuthorsController.GetAllAuthors();
            return Ok(authors);
        }

        [HttpPost]
        public async ValueTask<IActionResult> Post(CreateAuthorDto createAuthorDto)
        {
            var authorId = await CreateAutorController.CreateAutor(createAuthorDto);
            return Ok(new { AuthorId = authorId });
        }

        [HttpPatch("{id:guid}")]
        public async ValueTask<IActionResult> Patch(Guid id, UpdateAuthorRequest updateAuthorDto)
        {
            await UpdateAuthorController.Update(new UpdateAuthorDto(
                id,
                updateAuthorDto.Name,
                updateAuthorDto.BirthDate));

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async ValueTask<IActionResult> Delete(Guid id)
        {
            await DeleteAuthorByIdController.DeleteAuthorById(new DeleteAuthorByIdDto(id));
            return Ok();
        }

        [HttpGet("GetPage")]
        public async Task<IActionResult> GetPage([FromQuery] GetPagedAuthorsRequestDto request)
        {
            var response = await GetPagedAuthorsController.GetPagedAsync(request);
            return Ok(response);
        }
    }
}
