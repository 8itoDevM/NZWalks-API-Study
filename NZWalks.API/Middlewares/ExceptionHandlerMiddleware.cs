using System.Net;

namespace NZWalks.API.Middlewares {
    public class ExceptionHandlerMiddleware {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionHandlerMiddleware(RequestDelegate next,
            ILogger<ExceptionHandlerMiddleware> logger) {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext) {
            try {
                await next(httpContext);
            } catch (Exception ex){
                var errorId = Guid.NewGuid();

                logger.LogError(ex, $"{errorId} : {ex.Message}");

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new {
                    Id = errorId,
                    ErrorMessage = "Something went wrong! We are looking into it."
                };

                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
