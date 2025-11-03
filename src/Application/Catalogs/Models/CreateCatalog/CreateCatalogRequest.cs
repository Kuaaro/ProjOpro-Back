namespace Application.Catalogs.Models.CreateCatalog;

public sealed record CreateCatalogRequest(string Name, string Description, int ParentCatalogId);