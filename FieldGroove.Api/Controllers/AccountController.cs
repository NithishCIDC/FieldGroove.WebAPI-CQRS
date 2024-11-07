using FieldGroove.Api.JwtAuthToken;
using FieldGroove.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using FieldGroove.Domain.Interfaces;
using MediatR;
using FieldGroove.Application.CQRS.Accounts.IsRegistered;
using FieldGroove.Application.CQRS.Accounts.Register;

namespace FieldGroove.Api.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IConfiguration configuration;
		private readonly IUnitOfWork unitOfWork;
		private readonly ISender sender;
		public AccountController(IConfiguration configuration, IUnitOfWork unitOfWork,ISender sender)
		{
			this.configuration = configuration;
			this.unitOfWork = unitOfWork;
			this.sender = sender;
		}

		// Login Action in Api Controller

		[HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login([FromBody] IsRegisteredQuery entity)
		{
            if (ModelState.IsValid)
            {
				//var isUser = await unitOfWork.UserRepository.IsRegistered(entity);
				bool isUser = await sender.Send(entity);
                if (isUser)
                {
					var JwtToken = new JwtToken(configuration);
					var response = new
					{
						User = entity.Email!,
						Token = JwtToken.GenerateJwtToken(entity.Email!),
                        Status = "OK",
						Timestamp = DateTime.Now
					};
                    return Ok(response);
                }
                return NotFound("User Not Found");
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
                bool isUser = await sender.Send(new IsRegisteredQuery { Email = entity.Email,Password=entity.Password});
                if (!isUser)
				{
					bool response =await sender.Send(entity);
					return response? Ok(): StatusCode(500, "An internal server error occurred.");
				}
				return Conflict(new { error = "User already registered" });
			}
			return BadRequest(entity);
		 }
	}
}
