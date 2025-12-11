namespace BookManager.Cross.Entities.Interfaces
{
    public interface IExceptionHandler<ExeptionType>
        where ExeptionType : Exception
    {
        ValueTask<ProblemDetails> Handle(ExeptionType exception);
    }
}
