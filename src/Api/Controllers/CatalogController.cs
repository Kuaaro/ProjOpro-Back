using Application.Catalogs;
using Application.Catalogs.Models.CreateCatalog;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("catalogs")]
public sealed class CatalogController(ICatalogService catalogService) : ControllerBase
{
	[HttpPost]
	[ProducesResponseType<CreateCatalogResponse>(201)]
	public async Task<IActionResult> CreateCatalog(
		[FromBody] CreateCatalogRequest body)
	{
		var response = await catalogService.CreateCatalog(body);
		return Created(string.Empty, response);
	}
}