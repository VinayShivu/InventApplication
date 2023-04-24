using InventApplication.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace InventApplication.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        #region Private
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = JsonSerializer.Serialize(new
            {
                message = ex.Message,
                currentDate = DateTime.Now
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
        private static Task HandleRepositoryExceptionAsync(HttpContext context, RepositoryException ex, HttpStatusCode code = HttpStatusCode.BadRequest)
        {
            var result = JsonSerializer.Serialize(new
            {
                message = ex.Message,
                currentDate = DateTime.Now
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
        #endregion

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NoResultsException ex)
            {
                await HandleRepositoryExceptionAsync(context, ex, HttpStatusCode.NotFound);
            }
            catch (RepositoryException ex)
            {
                await HandleRepositoryExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                if (!context.RequestAborted.IsCancellationRequested)
                {
                    var unHandledEx = new Exception($"Unhandled Error in : {context.Request.Method} " +
                           $"{context.Request.Path.Value}", ex);
                    _ = unHandledEx.Message;
                }

                await HandleExceptionAsync(context, ex);
            }
        }
    }
}
