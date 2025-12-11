namespace BookManager.Cross.ExceptionHandlers.Implements
{
    public class GeneralExceptionHandler : IExceptionHandler<GeneralException>
    {
        public ValueTask<ProblemDetails> Handle(GeneralException exception)
        {
            return ValueTask.FromResult(
                new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Type = StatusCodes.Status500InternalServerErrorType,
                    Title = exception.Message,
                    Detail = exception.Detail
                });
        }
    }
}
