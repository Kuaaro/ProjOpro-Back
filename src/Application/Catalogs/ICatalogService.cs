using Application.Catalogs.Models.CreateCatalog;
using Application.Catalogs.Models.GetCatalogChildren;

namespace Application.Catalogs;

public interface ICatalogService
{
	Task<CreateCatalogResponse> CreateCatalog(CreateCatalogRequest request);
	Task<GetCatalogChildrenResponse> GetCatalogChildren(int id);
}