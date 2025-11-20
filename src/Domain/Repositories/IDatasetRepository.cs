using Domain.Entities;

namespace Domain.Repositories;

public interface IDatasetRepository
{
    void Add(DataSet dataset);
    Task SaveChanges(CancellationToken cancellationToken = default);
    Task<DataSet?> GetById(int id);
    Task<DataSet?> GetByName(string name);
    Task<IReadOnlyList<DataSet>> GetByParentId(int parentId);
}
