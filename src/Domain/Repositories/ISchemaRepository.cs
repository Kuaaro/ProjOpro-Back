using Domain.Entities;

namespace Domain.Repositories;

public interface ISchemaRepository
{
    void Add(Schema schema);
    Task<List<Schema>> GetAll();
    Task SaveChanges(CancellationToken cancellationToken = default);
}
