using Domain.Entities;

namespace Domain.Repositories;

public interface ISensorRouterRepository
{
	void Add(SensorRouter sensorRouter);
	Task SaveChanges(CancellationToken cancellationToken = default);
	Task<IReadOnlyList<SensorRouter>> GetBySensorId(int sensorId);
}
