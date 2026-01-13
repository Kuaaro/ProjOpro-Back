using Application.Datasets.Models.CreateDataset;
using Application.Datasets.Models.GetDataset;
using Application.Datasets.Models.ModifyDataset;
using Domain.Entities;

namespace Application.Datasets;

public interface IDatasetService
{
    Task<CreateDatasetResponse> CreateDataset(CreateDatasetRequest request);
    Task<GetDatasetResponse> GetDataset(int id);
    Task ModifyDataset(int id, ModifyDatasetRequest request);
    Task<List<DataEntry>> GetDatasetData(int datasetId);
}
