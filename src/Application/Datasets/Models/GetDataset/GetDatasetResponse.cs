namespace Application.Datasets.Models.GetDataset;

public sealed record GetDatasetResponse(
	string Name,
	string Description,
	string ContactPoint,
	List<string> Keywords,
	List<DistributionFull> Distributions,
	int SchemaId);

