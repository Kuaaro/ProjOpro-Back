namespace Application.Catalogs.Models.GetCatalogChildren;

public sealed record GetCatalogChildrenResponse(
	List<NameIdPair> Catalogs,
	List<NameIdPair> Datasets);

