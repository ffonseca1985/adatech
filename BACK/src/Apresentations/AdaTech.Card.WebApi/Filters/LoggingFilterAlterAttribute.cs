using AdaTech.Application.Card.Commands;
using Microsoft.AspNetCore.Mvc.Filters;


namespace AdaTech.Card.WebApi.Filters
{
    using AdaTech.Domain.Models;
    public class LoggingFilterAlterAttribute : IActionFilter, IExceptionFilter
    {
        private readonly ILogger<LoggingFilterAlterAttribute> _logger;

        public LoggingFilterAlterAttribute(ILogger<LoggingFilterAlterAttribute> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Executing...");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

            var value = (Card)((Microsoft.AspNetCore.Mvc.ObjectResult)context.Result!).Value!;

            if (value != null)
            {
                _logger.LogInformation($"{DateTime.Now} - Card {value.Id} - {value!.Titulo} - Alterado");
            }
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogInformation($"ERRO: ${context.Exception?.Message}");
        }
    }
}
