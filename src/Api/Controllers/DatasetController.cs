using Application.Datasets;
using Application.Datasets.Models.CreateDataset;
using Application.Datasets.Models.GetDataset;
using Application.Datasets.Models.ModifyDataset;
using Domain.Entities;
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
	[ProducesResponseType(204)]
	public async Task<IActionResult> ModifyDataset(
		int id,
		[FromBody] ModifyDatasetRequest body)
	{
		await datasetService.ModifyDataset(id, body);
		return Ok();
	}

    [HttpGet("data/{id}")]
    [ProducesResponseType<List<DataEntry>>(200)]
    public async Task<IActionResult> GetDatasetData(int id)
    {
        var data = await datasetService.GetDatasetData(id);
        return Ok(data);
    }
}

