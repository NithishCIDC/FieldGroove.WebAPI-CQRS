using MediatR;
using Microsoft.AspNetCore.Mvc;
using FieldGroove.Application.CQRS.Accounts.IsRegistered;
using FieldGroove.Application.CQRS.Accounts.Register;
using FieldGroove.Domain.Models;
using FieldGroove.Application.CQRS.Accounts.Login;

namespace FieldGroove.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ISender sender;
        public AccountController(IConfiguration configuration, ISender sender)
        {
            this.configuration = configuration;
            this.sender = sender;
        }

        // Login Action in Api Controller

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login([FromBody] LoginQuery entity)
        {
            if (ModelState.IsValid)
            {
                var response = await sender.Send(entity);
                return response is not null ? Ok(response) : NotFound("User Not Found");
            }
            return BadRequest();
        }

        // Register Action in Api Controller

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register([FromBody] RegisterCommand entity)
        {
            if (ModelState.IsValid)
            {
                bool isUser = await sender.Send(new IsRegisteredQuery { Email = entity.Email, Password = entity.Password });
                if (!isUser)
                {
                    bool response = await sender.Send(entity);
                    return response ? Ok() : StatusCode(500, "An internal server error occurred.");
                }
                return Conflict(new { error = "User already registered" });
            }
            return BadRequest(entity);
        }
    }
}
