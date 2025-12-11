namespace BookManager.Cross.Entities.Interfaces
{
    public interface IWebExceptionHandler
    {
        ValueTask<ProblemDetails> Handle(Exception ex, bool includeDetails);
    }
}
