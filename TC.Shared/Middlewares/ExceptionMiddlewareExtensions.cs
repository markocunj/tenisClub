using Microsoft.AspNetCore.Builder;

namespace TC.Shared.Middlewares
{
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Adds <see cref="ExceptionMiddleware"/> to your application pipeline to handle all unhandled exceptions.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
