using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using Shop.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Shop.API.ApiFilters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(NotFoundRecordException))
            {
                HandleNotFoundRecordException(context);
            }
            else if (context.Exception.GetType() == typeof(SqlException))
            {
                HandleSqlException(context);
            }
            else if (context.Exception.GetType() == typeof(UnauthorizedAccessException))
            {
                HandleUnauthorizedAccessException(context);
            }
            else
            {
                HandleNotSupportedException(context);
            }

            base.OnException(context);
        }
        private static void HandleNotFoundRecordException(ExceptionContext context)
        {
            context.Result = new NotFoundObjectResult(
                CreateDetailMessage(
                   title: "There is no such data on the given parameters",
                   statusCode: HttpStatusCode.NotFound,
                   instance: context.HttpContext.Request.Path,
                   detail: context.Exception.Message
             ));
        }

        private static void HandleSqlException(ExceptionContext context)
        {
            SqlException ex = context.Exception as SqlException;
            context.Result = new ObjectResult(CreateDetailMessage(
                   title: "Database Exception",
                   statusCode: HttpStatusCode.InternalServerError,
                   instance: context.HttpContext.Request.Path,
                   detail: context.Exception.Message
               ));
        }

        private static void HandleUnauthorizedAccessException(ExceptionContext context)
        {
            context.Result = new UnauthorizedObjectResult(CreateDetailMessage(
                    title: "Unauthorized Access",
                    statusCode: HttpStatusCode.Unauthorized,
                    instance: context.HttpContext.Request.Path,
                    detail: context.Exception.Message
                ));
        }
        private static void HandleNotSupportedException(ExceptionContext context)
        {
            context.Result = new ObjectResult(CreateDetailMessage(
                    title: "An error occurred while processing your request.",
                    statusCode: HttpStatusCode.InternalServerError,
                    instance: context.HttpContext.Request.Path,
                    detail: $"{context.Exception.Message} - Inner Exception: {(context.Exception.InnerException is not null ? context.Exception.InnerException.Message : string.Empty)}"
                ));
        }

        private static ProblemDetails CreateDetailMessage(string title, HttpStatusCode statusCode, string instance, string detail)
        {
            return new ProblemDetails
            {
                Title = title,
                Status = (int)statusCode,
                Instance = instance,
                Detail = detail
            };
        }
    }
}
