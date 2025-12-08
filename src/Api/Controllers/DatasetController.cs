using Application.Datasets;
using Application.Datasets.Models.CreateDataset;
using Application.Datasets.Models.GetDataset;
using Application.Datasets.Models.ModifyDataset;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("datasets")]
public sealed class DatasetController(IDatasetService datasetService) : ControllerBase
{
	[HttpGet("{id}")]
	[ProducesResponseType<GetDatasetResponse>(200)]
	public async Task<IActionResult> GetDataset(int id)
	{
		var response = await datasetService.GetDataset(id);
		return Ok(response);
    }

    [HttpPost]
	[ProducesResponseType<CreateDatasetResponse>(201)]
	public async Task<IActionResult> CreateDataset(
		[FromBody] CreateDatasetRequest body)
	{
        var response = await datasetService.CreateDataset(body);
        return Ok(response);
    }

	[HttpPut("{id}")]
	public async Task<IActionResult> ModifyDataset(
		int id,
		[FromBody] ModifyDatasetRequest body)
	{
		var response = await datasetService.ModifyDataset(id, body);
		return Ok(response);
	}
}

