using Domain.Entities;

namespace Domain.Repositories;

public interface IDataEntryRepository
{
	void Add(DataEntry dataEntry);
	Task SaveChanges(CancellationToken cancellationToken = default);
}
