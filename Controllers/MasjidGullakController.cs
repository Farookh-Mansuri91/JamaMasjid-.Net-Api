using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SunniNooriMasjidAPI.Data.Entities;
using SunniNooriMasjidAPI.Features.MasjidGullak.Commands;
using SunniNooriMasjidAPI.Features.MasjidGullak.Queries;
using SunniNooriMasjidAPI.Features.Models.MasjidGullak.Request;
using SunniNooriMasjidAPI.Features.Models.SadqaMember.Request;
using SunniNooriMasjidAPI.Features.SadqaMember.Commands;

namespace SunniNooriMasjidAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MasjidGullakController : ControllerBase
{
    private readonly IMediator _mediator;

    public MasjidGullakController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[Authorize(Roles = "Treasurer")]
    [HttpGet("GetMasjidGullakData")]
    public async Task<IActionResult> GetGullak()
    {
        var result = await _mediator.Send(new GetGullakQuery());
        return Ok(result);
    }

    //[Authorize(Roles = "Treasurer, Admin")]
    [HttpPost("addMasjidGullakData")]
    public async Task<IActionResult> AddMasjidGullakPayment([FromBody] AddGullakCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        // Send the command via mediator
        var result = await _mediator.Send(command);

        if (!result.Success)
            return BadRequest(new { Message = result.ErrorMessage });

        return Ok(new { Message = "Gullak collection amount added successfully." });
    }

    //[Authorize(Roles = "Treasurer")]
    [HttpPut("updateMasjidGullakData")]
    public async Task<IActionResult> UpdateMasjidGullakPayment([FromBody] UpdateGullakCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        // Send the command via mediator
        var result = await _mediator.Send(command);

        if (!result.Success)
            return BadRequest(new { Message = result.ErrorMessage });

        return Ok(new { Message = "Gullak collection amount updated successfully." });
    }
}
