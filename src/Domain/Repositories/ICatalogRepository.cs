using Domain.Entities;

namespace Domain.Repositories;

public interface ICatalogRepository
{
	void Add(Catalog catalog);
	
	Task SaveChanges(CancellationToken cancellationToken = default);
}