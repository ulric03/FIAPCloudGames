using System.Net;
using FIAPCloudGames.WebAPI.Contracts;
using FIAPCloudGames.Domain.Core;

namespace FIAPCloudGames.WebAPI.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var correlationId = context.TraceIdentifier;
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                _logger.LogError(ex, "Erro inesperado. CorrelationId: {CorrelationId}", correlationId);

                var error = new Error("Server.Unexpected", "Ocorreu um erro inesperado. Tente novamente mais tarde.");
                var response = new ApiErrorResponse(new[] { error });

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}

