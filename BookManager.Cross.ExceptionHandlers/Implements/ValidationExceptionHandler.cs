namespace BookManager.Cross.ExceptionHandlers.Implements
{
    public class ValidationExceptionHandler : IExceptionHandler<ValidationException>
    {
        public ValueTask<ProblemDetails> Handle(ValidationException exception)
        {
            return ValueTask.FromResult(
                new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = StatusCodes.Status400BadRequestType,
                    Title = "Error en los datos de entrada.",
                    Detail = "Se encontraron uno o más errores de validación de datos.",
                    InvalidParams = exception.Failures
                });
        }
    }
}
