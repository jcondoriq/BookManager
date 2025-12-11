namespace BookManager.Cross.ExceptionHandlers.Implements
{
    public class WebExceptionHandler : IWebExceptionHandler
    {
        readonly static Dictionary<Type, Type> ExceptionHandlers = new();

        public WebExceptionHandler(Assembly assembly)
        {
            Type[] Types = assembly.GetTypes();

            foreach (Type type in Types)
            {
                var Handlers = type.GetInterfaces()
                    .Where(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IExceptionHandler<>));
                foreach (Type Handler in Handlers)
                {
                    var ExceptionType = Handler.GetGenericArguments()[0];
                    ExceptionHandlers.TryAdd(ExceptionType, type);
                }
            }
        }

        public async ValueTask<ProblemDetails> Handle(Exception ex, bool includeDetails)
        {
            ProblemDetails Problem;

            if (ExceptionHandlers.TryGetValue(ex.GetType(), out Type HandlerType))
            {
                var Handler = Activator.CreateInstance(HandlerType);

                Problem = await (ValueTask<ProblemDetails>)HandlerType.GetMethod(
                                nameof(IExceptionHandler<Exception>.Handle))?
                                .Invoke(Handler, new object[] { ex })!;

                if (!includeDetails)
                {
                    Problem.Detail = "Consulte al administrador.";
                }
            }
            else
            {
                // No encontro el manejador
                string Title;
                string Detail;
                if (includeDetails)
                {
                    Title = $"Un error ocurrió: {ex.Message}";
                    Detail = ex.ToString();
                }
                else
                {
                    Title = "Ha ocurrido un error al procesar la respuesta";
                    Detail = "Consulte al administrador";
                }

                Problem = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Type = StatusCodes.Status500InternalServerErrorType,
                    Title = Title,
                    Detail = Detail
                };
            }
            return Problem;
        }
    }
}
