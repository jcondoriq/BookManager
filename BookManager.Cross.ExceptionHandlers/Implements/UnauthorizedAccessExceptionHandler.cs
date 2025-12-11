namespace BookManager.Cross.ExceptionHandlers.Implements
{
    internal class UnauthorizedAccessExceptionHandler : IExceptionHandler<UnauthorizedAccessException>
    {
        public ValueTask<ProblemDetails> Handle(UnauthorizedAccessException exception)
        {
            return ValueTask.FromResult(
                        new ProblemDetails
                        {
                            Status = StatusCodes.Status401Unauthorized,
                            Type = StatusCodes.Status401UnauthorizedType,
                            Title = "Error de Authorización",
                            Detail = exception.Message
                        });
        }
    }
}
