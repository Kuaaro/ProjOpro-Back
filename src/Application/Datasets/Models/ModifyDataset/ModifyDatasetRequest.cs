namespace Application.Datasets.Models.ModifyDataset;

public sealed record ModifyDatasetRequest(
	string Name,
	string Description,
	string ContactPoint,
	List<string> Keywords,
	List<DistributionFull> Distributions,
	int SchemaId);

