using InventApplication.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.Text.Json;

namespace InventApplication.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        /// <summary>
        /// ExceptionHandlingMiddleware
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
            this._next = next;
        }

        #region Private
        private static Task HandleNotFoundException(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.NotFound;
            var result = JsonSerializer.Serialize(new
            {
                message = ex.Message,
                currentDate = DateTime.Now
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
        private static Task HandleConflictException(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.Conflict;
            var result = JsonSerializer.Serialize(new
            {
                message = ex.Message,
                currentDate = DateTime.Now
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
        private static Task HandleNoContentException(HttpContext context, CustomException ex)
        {
            HttpStatusCode code = HttpStatusCode.NoContent;
            context.Response.Headers.Add("Message", ex.Message);
            context.Response.StatusCode = (int)code;
            return Task.FromResult(new NoContentResult());
        }
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
        private static string MessageBody(HttpContext context, Exception ex)
        {
            StringBuilder message = new();
            message.Append('{');
            message.Append($"   \"Method\"  :   \"{context.Request.Method}\",");
            message.Append($"   \"Path\"  :   \"{context.Request.Path}\",");
            message.Append($"   \"ResponseCode\"  :   {context.Response.StatusCode},");
            message.Append($"   \"TimeStamp\"  :   {DateTime.UtcNow:o},");
            message.Append($"   \"ProcessId\"  :   {Environment.ProcessId},");
            message.Append($"   \"LocalIpAddress\"  :   {context.Request.HttpContext.Connection.LocalIpAddress}:{context.Request.HttpContext.Connection.LocalPort},");
            message.Append($"   \"RemoteIpAddress\"  :   {context.Request.HttpContext.Connection.RemoteIpAddress},");
            message.Append($"   \"Message\"  :   {ex.Message},");
            message.Append($"   \"StackTrace\"  :   {ex.StackTrace},");
            message.Append($"   \"Inner Exception\"  :   {ex.InnerException},");
            message.Append("}\n");
            return message.ToString();
        }
        #endregion

        #region Public
        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError("{message}", MessageBody(context, ex));
                await HandleNotFoundException(context, ex);
            }
            catch (ConflictException ex)
            {
                _logger.LogError("{message}", MessageBody(context, ex));
                await HandleConflictException(context, ex);
            }
            catch (CustomException ex)
            {
                _logger.LogError("{message}", MessageBody(context, ex));
                await HandleNoContentException(context, ex);
            }
            catch (Exception ex)
            {
                if (!context.RequestAborted.IsCancellationRequested)
                {
                    var unHandledEx = new Exception($"Unhandled Error in : {context.Request.Method} " +
                           $"{context.Request.Path.Value}", ex);
                    _logger.LogError("{message}", MessageBody(context, unHandledEx));
                }
                await HandleExceptionAsync(context, ex);
            }
        }
        #endregion
    }
}
