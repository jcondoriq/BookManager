namespace BookManager.Cross.ExceptionHandlers.Implements
{
    public class WebExceptionHandlerMiddleware
    {
        public static async Task WriteResponse(HttpContext context,
            bool includeDetails, IWebExceptionHandler handler)
        {
            IExceptionHandlerFeature ExceptionDetail =
                context.Features.Get<IExceptionHandlerFeature>();

            Exception Exception = ExceptionDetail.Error;

            if (Exception != null)
            {
                var ProblemDetails = await handler.Handle(Exception, includeDetails);

                context.Response.ContentType = "application/problem+json";
                context.Response.StatusCode = ProblemDetails.Status;

                var Stream = context.Response.Body;
                await JsonSerializer.SerializeAsync(Stream, ProblemDetails);
            }
        }
    }
}
