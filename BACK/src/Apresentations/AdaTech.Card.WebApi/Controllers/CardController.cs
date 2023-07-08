using AdaTech.Application.Card.Commands;
using AdaTech.Application.Card.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AdaTech.Card.WebApi.Controllers
{
    [Route("api/card")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CardController> _logger;
        public CardController(IMediator mediator, ILogger<CardController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get([Required] string id)
        {
            try
            {
                var query = new FindCardByIdQuery(id);
                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message,
                                 exception: ex);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = new FindAllCardsQuery();
                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message,
                                 exception: ex);
                throw;
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([Required]string id, [FromBody] CardCommand command)
        {
            try
            {
                var updateCommand = new UpdateCardCommand(id, command.Titulo, command.Conteudo, command.Lista);
                var result = await _mediator.Send(updateCommand);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message,
                                 exception: ex);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddCardCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message,
                                 exception: ex);
                throw;
            }
        }
    }
}
