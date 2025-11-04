using Application.Datasets.Models.CreateDataset;
using Application.Datasets.Models.GetDataset;
using Application.Datasets.Models.ModifyDataset;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("datasets")]
public sealed class DatasetController : ControllerBase
{
	[HttpGet("{id}")]
	[ProducesResponseType<GetDatasetResponse>(200)]
	public async Task<IActionResult> GetDataset(int id)
	{
		return Ok();
	}

	[HttpPost]
	[ProducesResponseType<CreateDatasetResponse>(201)]
	public async Task<IActionResult> CreateDataset(
		[FromBody] CreateDatasetRequest body)
	{
		return Created(string.Empty, null);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> ModifyDataset(
		int id,
		[FromBody] ModifyDatasetRequest body)
	{
		return NoContent();
	}
}

