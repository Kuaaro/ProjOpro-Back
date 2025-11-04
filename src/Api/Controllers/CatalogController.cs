using Application.Catalogs;
using Application.Catalogs.Models.CreateCatalog;
using Application.Catalogs.Models.GetCatalogChildren;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("catalogs")]
public sealed class CatalogController(ICatalogService catalogService) : ControllerBase
{
	[HttpGet("children/{id}")]
	[ProducesResponseType<GetCatalogChildrenResponse>(200)]
	public async Task<IActionResult> GetCatalogChildren(int id)
	{
		return Ok();
	}

	[HttpPost]
	[ProducesResponseType<CreateCatalogResponse>(201)]
	public async Task<IActionResult> CreateCatalog(
		[FromBody] CreateCatalogRequest body)
	{
		var response = await catalogService.CreateCatalog(body);
		return Created(string.Empty, response);
	}
}