using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Persistence.Repositories;

internal sealed class SensorRouterRepository(ApplicationDbContext dbContext) : ISensorRouterRepository
{
	public void Add(SensorRouter sensorRouter)
	{
		dbContext.SensorRouters.Add(sensorRouter);
	}

	public Task SaveChanges(CancellationToken cancellationToken = default)
	{
		return dbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task<IReadOnlyList<SensorRouter>> GetBySensorId(int sensorId)
	{
		return await dbContext.SensorRouters
			.Where(sr => sr.SensorId == sensorId)
			.ToListAsync();
	}
}
