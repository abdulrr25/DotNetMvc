using _14Day_Filters.Logger;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _14Day_Filters.Filters
{
    public class IETFilter :ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            FileLogger.CurrentLogger.Log($"Calling :{context.HttpContext.Request.Path.Value} ");
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            FileLogger.CurrentLogger.Log($"Called :{context.HttpContext.Request.Path.Value} ");
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            FileLogger.CurrentLogger.Log($"Generating View :{context.HttpContext.Request.Path.Value} ");

        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            FileLogger.CurrentLogger.Log($"View Generated :{context.HttpContext.Request.Path.Value} ");

        }
    }
}
