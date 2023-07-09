using AdaTech.Application.User.Query;
using AdaTech.Infra.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdaTech.Card.WebApi.Controllers
{
    [Route("login")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly IMediator _mediator;

        public LoginController(TokenService tokenService, IMediator mediator)
        {
            _tokenService = tokenService;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Index([FromBody]IsValidUserQuery request)        
        {
            var isValid = await _mediator.Send(request);
            if (isValid)
            {
                var token = _tokenService.GenerateToken(request.UserName);
                return Ok(token);
            }

            return Unauthorized();
        }
    }
}
