using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FieldGroove.Application.CQRS.Leads.CreateLead;
using FieldGroove.Application.CQRS.Leads.DeleteLead;
using FieldGroove.Application.CQRS.Leads.UpdateLead;
using FieldGroove.Application.CQRS.Leads.GetByIdLead;
using FieldGroove.Application.CQRS.Leads.GetAllLeads;

namespace FieldGroove.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController(ISender sender) : ControllerBase
    {

        //Leads Action in Api Controller

        [HttpGet("Leads")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Leads()
        {
            var query = new GetAllLeadsQuery();
            var result = await sender.Send(query);
            var response = new
            {
                Data = result,
                TotalCount = result.Count,
                Status = "success",
                Timestamp = DateTime.UtcNow.ToString("o")
            };
            return Ok(response);
        }

        [HttpGet("Leads/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Leads(int id)
        {
            var query = new GetByIdLeadQuery(id);
            var User = await sender.Send(query);
            return User is not null? Ok(User):NotFound();
        }

        //CreateLead Action in Api Controller

        [HttpPost("CreateLead")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateLead([FromBody] CreateLeadCommand model)
        {
            if (ModelState.IsValid)
            {
                bool response = await sender.Send(model);
                if (response) return Ok();
            }
            return BadRequest();
        }

        //EditLead Action in Api Controller

        [HttpPut("EditLead")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditLead([FromBody] UpdateLeadCommand model)
        {
            if (ModelState.IsValid)
            {
                return await sender.Send(model) ? Ok() : NotFound();
            }
            return BadRequest();
        }

        // Delete Action in Api Controller 

        [HttpDelete("DeleteLead/{id:int}")]
        public async Task<IActionResult> DeleteLead(int id)
        {
            var query = new DeleteLeadCommand(id);
            return await sender.Send(query) ? Ok() : NotFound();
        }
    }
}
