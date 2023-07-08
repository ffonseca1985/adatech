using Microsoft.AspNetCore.Mvc.Filters;
namespace AdaTech.Card.WebApi.Filters
{
    public class LoggingFilterAttribute : IActionFilter
    {
        private readonly ILogger<LoggingFilterAttribute> _logger;

        public LoggingFilterAttribute(ILogger<LoggingFilterAttribute> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Request received: " + context.HttpContext.Request.Path);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("Response sent: " + context.HttpContext.Response.StatusCode);
        }
    }
}
