using Domain.Entities;

namespace Domain.Repositories;

public interface ICatalogRepository
{
	void Add(Catalog catalog);
	
	Task SaveChanges(CancellationToken cancellationToken = default);

	Task<IReadOnlyList<Catalog>> GetByParentId(int parentId);

    Task<Catalog?> GetById(int id);
}