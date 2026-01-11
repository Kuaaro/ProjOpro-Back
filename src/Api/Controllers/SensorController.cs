using Application.Sensors;
using Application.Sensors.Models.CreateSensorRouter;
using Application.Sensors.Models.SendSensorData;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("data/sensor")]
public sealed class SensorController(ISensorService sensorService) : ControllerBase
{
	[HttpPost("sensorrouter")]
	[ProducesResponseType<CreateSensorRouterResponse>(201)]
	public async Task<IActionResult> CreateSensorRouter(
		[FromBody] CreateSensorRouterRequest body)
	{
		var response = await sensorService.CreateSensorRouter(body);
		return Created(string.Empty, response);
	}

	[HttpPost("senddata")]
	[ProducesResponseType(200)]
	public async Task<IActionResult> SendSensorData(
		[FromBody] SendSensorDataRequest body)
	{
		await sensorService.SendSensorData(body);
		return Ok();
	}
}
