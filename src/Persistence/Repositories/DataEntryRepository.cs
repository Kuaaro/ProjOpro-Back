using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Persistence.Repositories;

internal sealed class DataEntryRepository(ApplicationDbContext dbContext) : IDataEntryRepository
{
	public void Add(DataEntry dataEntry)
	{
		dbContext.DataEntries.Add(dataEntry);
	}

	public Task SaveChanges(CancellationToken cancellationToken = default)
	{
		return dbContext.SaveChangesAsync(cancellationToken);
	}

    public Task<List<DataEntry>> GetByDatasetId(int datasetId)
    {
        return dbContext.DataEntries
            .Where(x => x.DatasetId == datasetId)
            .ToListAsync();
    }
}
