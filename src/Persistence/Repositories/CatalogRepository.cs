using Domain.Entities;
using Domain.Repositories;
using Persistence.Database;

namespace Persistence.Repositories;

internal sealed class CatalogRepository(ApplicationDbContext dbContext)
	: ICatalogRepository
{
	public void Add(Catalog catalog)
		=> dbContext.Catalogs.Add(catalog);
	
	public Task SaveChanges(CancellationToken cancellationToken)
		=> dbContext.SaveChangesAsync(cancellationToken);
}