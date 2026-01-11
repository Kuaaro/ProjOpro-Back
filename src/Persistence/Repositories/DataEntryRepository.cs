using Domain.Entities;
using Domain.Repositories;
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
}
