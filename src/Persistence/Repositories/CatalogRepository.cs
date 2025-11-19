using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Persistence.Repositories;

internal sealed class CatalogRepository(ApplicationDbContext dbContext)
	: ICatalogRepository
{
	public void Add(Catalog catalog)
		=> dbContext.Catalogs.Add(catalog);
	
	public Task SaveChanges(CancellationToken cancellationToken)
		=> dbContext.SaveChangesAsync(cancellationToken);

    public async Task<IReadOnlyList<Catalog>> GetByParentId(int parentId)
    {
        return await dbContext.Catalogs
            .Where(c => c.ParentId == parentId)
            .ToListAsync();
    }

    public Task<Catalog?> GetById(int id)
    {
        return dbContext.Catalogs
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}