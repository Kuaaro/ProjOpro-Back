using Application.Catalogs.Models.CreateCatalog;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Catalogs;

internal sealed class CatalogService(ICatalogRepository catalogRepository) : ICatalogService
{
	public async Task<CreateCatalogResponse> CreateCatalog(CreateCatalogRequest request)
	{
		var catalog = new Catalog(request.Name, request.Description, request.ParentCatalogId);
		catalogRepository.Add(catalog);
		await catalogRepository.SaveChanges();
		return new CreateCatalogResponse(catalog.Id);
	}
}