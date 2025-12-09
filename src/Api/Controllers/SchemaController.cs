using Application.Schemas;
using Application.Schemas.Models.CreateSchema;
using Application.Schemas.Models.GetSchema;
using Application.Schemas.Models.GetSchemaList;
using Application.Schemas.Models.ModifySchema;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("schemas")]
public sealed class SchemaController(ISchemaService schemaService) : ControllerBase
{
	[HttpGet("list")]
	[ProducesResponseType<GetSchemaListResponse>(200)]
	public async Task<IActionResult> GetSchemaList()
	{
        var response = await schemaService.GetSchemaListAsync();
        return Ok(response);
	}

	[HttpGet("{id}")]
	[ProducesResponseType<GetSchemaResponse>(200)]
	public async Task<IActionResult> GetSchema(int id)
	{
		return Ok();
	}

	[HttpPost]
	[ProducesResponseType<CreateSchemaResponse>(201)]
	public async Task<IActionResult> CreateSchema(
		[FromBody] CreateSchemaRequest body)
	{
        var response = await schemaService.CreateSchema(body);
        return Created(string.Empty, response);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> ModifySchema(
		int id,
		[FromBody] ModifySchemaRequest body)
	{
		await schemaService.ModifySchema(id, body);
		return NoContent();
	}
}

