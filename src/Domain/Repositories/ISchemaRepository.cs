using Domain.Entities;

namespace Domain.Repositories;

public interface ISchemaRepository
{
    Task<List<Schema>> GetAll();
    Task SaveChanges(CancellationToken cancellationToken = default);
}
