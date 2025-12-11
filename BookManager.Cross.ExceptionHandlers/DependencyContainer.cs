using BookManager.Cross.ExceptionHandlers.Implements;

namespace BookManager.Cross.ExceptionHandlers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddWebExceptionHandler(
            this IServiceCollection services, Assembly exceptionHandlerAsembly)
        {
            services.AddSingleton<IWebExceptionHandler>(provider =>
                        new WebExceptionHandler(exceptionHandlerAsembly));

            return services;
        }

        public static IServiceCollection AddWebExceptionHandler(
            this IServiceCollection services) =>
            services.AddWebExceptionHandler(Assembly.GetExecutingAssembly());

        public static IApplicationBuilder UseWebExceptionHandlerMiddleware(
            this IApplicationBuilder app, IHostEnvironment enviroment,
            IWebExceptionHandler handler)
        {
            app.Use((context, next) =>
                  WebExceptionHandlerMiddleware.WriteResponse(
                      context, enviroment.IsDevelopment(), handler));

            return app;
        }
    }
}
