using Application.Datasets.Models.CreateDataset;
using Application.Datasets.Models.GetDataset;
using Application.Datasets.Models.ModifyDataset;

namespace Application.Datasets;

public interface IDatasetService
{
    Task<CreateDatasetResponse> CreateDataset(CreateDatasetRequest request);
    Task<GetDatasetResponse> GetDataset(int id);
    Task ModifyDataset(int id, ModifyDatasetRequest request);
}
