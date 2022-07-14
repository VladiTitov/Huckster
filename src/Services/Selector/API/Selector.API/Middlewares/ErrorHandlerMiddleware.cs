using System.Net;
using System.Text.Json;
using FluentValidation;
using Selector.Core.Application.Wrappers;

namespace Selector.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>()
                {
                    Succeeded = false,
                    Message = error?.Message
                };

                switch (error)
                {
                    case ValidationException ex:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = ex.Errors.Select(_ => _.ErrorMessage);
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var responseMessage = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(responseMessage);
            }
        }
    }
}
