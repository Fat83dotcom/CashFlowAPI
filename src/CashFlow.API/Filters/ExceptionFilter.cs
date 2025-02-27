using CashFlow.Communication.Responses;
using CashFlow.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is CashFlowExceptions)
            {
                HandleProjectExeption(context);
            }
            else
            {
                ThrowUnknowerror(context);
            }
        }

        private void HandleProjectExeption(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidateException e)
            {
                ResponseErrorJson errorResponse = new(e.Errors);
                context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Result = new BadRequestObjectResult(errorResponse);
            }
            else
            {
                ResponseErrorJson errorResponse = new(context.Exception.Message);
                context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }

        private void ThrowUnknowerror(ExceptionContext context)
        {
            ResponseErrorJson errorResponse = new(ResourceErrorMessages.UNKNOW_ERROR);
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
