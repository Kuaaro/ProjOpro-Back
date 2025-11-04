namespace Application.Datasets.Models.GetDataset;

public sealed record DistributionFull(
	int DistributionId,
	string AccessUrl,
	string Description,
	string Format,
	bool Availability);

