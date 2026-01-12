using Application.UserFeedback;
using Application.UserFeedback.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("community")]
public sealed class UserFeedbackController(IUserFeedbackService userFeedbackService) : ControllerBase
{
    [HttpPost("userfeedback")]
    [ProducesResponseType<CreateUserFeedbackResponse>(201)]
    public async Task<IActionResult> CreateUserFeedback(
        [FromBody] CreateUserFeedbackRequest body)
    {
        var response = await userFeedbackService.CreateFeedback(body);
        return Created(string.Empty, response);
    }

    [HttpGet("userfeedback/{userFeedbackId:int}")]
    [ProducesResponseType<GetUserFeedbackDetails>(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetUserFeedbackDetails(
        [FromRoute] int userFeedbackId)
    {
        var response = await userFeedbackService.GetUserFeedback(userFeedbackId);
        if (response is null)
            return NotFound();

        return Ok(response);
    }
}
