using CashFlow.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is CashFlowExceptions)
            {
                
            }
            else
            {
                
            }

        }

        private void HandleProjectExeption(ExceptionContext context)
        {

        }

        private void ThrowUnknowerror(ExceptionContext context)
        {

        }
    }
}
