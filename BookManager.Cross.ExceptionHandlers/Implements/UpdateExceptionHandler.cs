namespace BookManager.Cross.ExceptionHandlers.Implements
{
    public class UpdateExceptionHandler : IExceptionHandler<UpdateException>
    {
        public ValueTask<ProblemDetails> Handle(UpdateException exception)
        {
            return ValueTask.FromResult(
                new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = StatusCodes.Status400BadRequestType,
                    Title = "Error de actualización.",
                    Detail = exception.Message,
                    InvalidParams = new Dictionary<string, List<string>>
                    {
                        {
                            "Entities", exception.Entries.ToList()
                        }
                    }
                });
        }
    }
}
