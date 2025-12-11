using BookManager.BusinessObjects.DTOs.GetPagedBooks;

namespace BookManager.BusinessObjects.Interfaces.Repositories
{
    public interface IGetPagedBooksRepository
    {
        ValueTask<(IEnumerable<BookItemDto>, int)> GetPagedAsync(string? normalizedSearch, int page, int pageSize);
    }
}
