using System;
using System.Net;
using System.Threading.Tasks;
using CourseWebApi.Model.Framework;
using Microsoft.AspNetCore.Http;

namespace CourseWebApi.WebAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate request;

        public ExceptionMiddleware(RequestDelegate request)
        {
            this.request = request;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await request(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is DuplicateException duplicationException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = duplicationException.Message
                }.ToString());
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = exception.Message
                }.ToString());
            }
        }

    }
}
