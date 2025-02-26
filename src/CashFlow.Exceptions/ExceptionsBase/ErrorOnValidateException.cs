using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Exceptions.ExceptionsBase
{
    public class ErrorOnValidateException : CashFlowExceptions
    {
        public List<string> Errors { get; set; } = [];
        public ErrorOnValidateException(List<string> errorMessages)
        {
            Errors = errorMessages;
        }

        public ErrorOnValidateException(string errorMessage)
        {
            Errors = [errorMessage];
        }
    }
}
