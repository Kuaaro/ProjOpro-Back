using Application.Catalogs.Models.CreateCatalog;

namespace Application.Catalogs;

public interface ICatalogService
{
	Task<CreateCatalogResponse> CreateCatalog(CreateCatalogRequest request);
}