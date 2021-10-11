using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Investeer
{
    public class ErrorHandlingFilter : ExceptionFilterAttribute
    {
        private ILogger<ErrorHandlingFilter> _Logger;

        public ErrorHandlingFilter(ILogger<ErrorHandlingFilter> logger)
        {
            _Logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            _Logger.LogError(context.Exception, exception.Message);

            context.ExceptionHandled = false; //optional 
        }
    }
}
