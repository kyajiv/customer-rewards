using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Customer.Rewards.Api.Exceptions.Filters
{
    public class InvalidCustomerIdExceptionFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is InvalidCustomerIdException httpResponseException)
            {
                // set response status to 400
                context.Result = new ObjectResult(httpResponseException.Message)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
