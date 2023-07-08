﻿using AdaTech.Application.Card.Commands;
using AdaTech.Application.Card.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AdaTech.Card.WebApi.Controllers
{
    [Route("cards")]
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
                var query = new FindCardByIdQuery(id);
                var search = await _mediator.Send(query);

                if (search == null)
                {
                    return NotFound();
                }

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
        public async Task<IActionResult> Post(AddCardCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message,
                                 exception: ex);
                throw;
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([Required] string id)
        {
            try
            {
                var query = new FindCardByIdQuery(id);
                var search = await _mediator.Send(query);

                if (search == null) {
                    return NotFound();
                }

                var command = new DeleteCardCommand(id);

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
