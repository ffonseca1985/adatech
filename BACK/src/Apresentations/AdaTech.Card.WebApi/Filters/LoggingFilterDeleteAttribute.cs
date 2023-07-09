using AdaTech.Application.Card.Commands;
using AdaTech.Application.Card.Queries;
using AdaTech.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdaTech.Card.WebApi.Filters
{
    public class LoggingFilterDeleteAttribute : IActionFilter, IExceptionFilter
    {
        private readonly ILogger<LoggingFilterAlterAttribute> _logger;
        private readonly IMediator _mediator;

        public LoggingFilterDeleteAttribute(ILogger<LoggingFilterAlterAttribute> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public void OnActionExecuting(ActionExecutingContext context) {}

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var id = (string)context.HttpContext.Request.RouteValues["id"]!;

            //Como foi enviado somente o id, tive que ir ao banco.
            var card = _mediator.Send(new FindCardByIdQuery(id)).Result;

            _logger.LogInformation($"{DateTime.Now} - Card {id} {card.Titulo} - Removido");
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogInformation($"ERRO: ${context.Exception?.Message}");
        }
    }
}
