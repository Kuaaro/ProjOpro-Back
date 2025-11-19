using Application.Catalogs.Models.CreateCatalog;
using Application.Catalogs.Models.GetCatalogChildren;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Catalogs;

internal sealed class CatalogService(ICatalogRepository catalogRepository, IDatasetRepository datasetRepository) : ICatalogService
{
	public async Task<CreateCatalogResponse> CreateCatalog(CreateCatalogRequest request)
	{
		var catalog = new Catalog(request.Name, request.Description, request.ParentCatalogId);
		catalogRepository.Add(catalog);
		await catalogRepository.SaveChanges();
		return new CreateCatalogResponse(catalog.Id);
	}

	public async Task<GetCatalogChildrenResponse> GetCatalogChildren(int parentId)
	{
        var childCatalogs = await catalogRepository.GetByParentId(parentId);

        var datasets = await datasetRepository.GetByParentId(parentId);

        var catalogPairs = childCatalogs
            .Select(c => new NameIdPair(c.Name, c.Id))
            .ToList();

        var datasetPairs = datasets
            .Select(d => new NameIdPair(d.Name, d.Id))
            .ToList();

        return new GetCatalogChildrenResponse(catalogPairs, datasetPairs);
    }
}