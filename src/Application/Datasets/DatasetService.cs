using Application.Datasets.Models.CreateDataset;
using Application.Datasets.Models.GetDataset;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Datasets;

internal sealed class DatasetService(IDatasetRepository datasetRepository) : IDatasetService
{
    public async Task<CreateDatasetResponse> CreateDataset(CreateDatasetRequest request)
    {
        var dataset = await datasetRepository.GetByName(request.Name);

        if (dataset is null)
        {
            dataset = new DataSet
            {
                Name = request.Name,
                Description = request.Description,
                ContactPoint = request.ContactPoint,
                Keywords = request.Keywords?.ToList() ?? new List<string>(),
                Distribution = new List<Distribution>(),
                ParentId = request.ParentId
            };

            datasetRepository.Add(dataset);
        }
        else
        {
            dataset.Name = request.Name;
            dataset.Description = request.Description;
            dataset.ContactPoint = request.ContactPoint;
            dataset.Keywords = request.Keywords?.ToList() ?? new List<string>();
        }

        if (request.Distributions is not null)
        {
            foreach (var d in request.Distributions)
            {
                var distribution = new Distribution
                {
                    AccessUrl = d.AccessUrl,
                    Description = d.Description,
                    Format = d.Format,
                    IsAvailable = d.Availability,
                    DataSet = dataset
                };

                dataset.Distribution.Add(distribution);
            }
        }

        await datasetRepository.SaveChanges();

        return new CreateDatasetResponse(dataset.Id);
    }

    public async Task<GetDatasetResponse> GetDataset(int id)
    {
        var dataset = await datasetRepository.GetById(id);

        var distributionDtos = dataset.Distribution
            .Select(d => new Models.GetDataset.DistributionFull(
                d.Id,           
                d.AccessUrl,             
                d.Description,  
                d.Format,   
                d.IsAvailable  
            ))
            .ToList();

        return new GetDatasetResponse(
            dataset.Name,
            dataset.Description,
            dataset.ContactPoint,
            dataset.Keywords.ToList(),
            distributionDtos,
            dataset.ParentId
        );

    }

}
