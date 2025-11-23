using MediatR;
using Microsoft.AspNetCore.Mvc;
using SunniNooriMasjidAPI.Features.Login.Queries;
using SunniNooriMasjidAPI.Features.Models.Login.Request;

namespace SunniNooriMasjidAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("memberLogin")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request body cannot be null.");
            }

            try
            {
                var response = await _mediator.Send(new GetLoginQuery(request.Username, request.Password));
                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Log the exception if needed for debugging purposes.
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                // Log general exceptions if needed for debugging purposes.
                return StatusCode(500, "An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
