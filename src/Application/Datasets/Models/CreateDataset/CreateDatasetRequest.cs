namespace Application.Datasets.Models.CreateDataset;

public sealed record CreateDatasetRequest(
	string Name,
	string Description,
	string ContactPoint,
	List<string> Keywords,
	List<DistributionFull> Distributions,
	int SchemaId);

