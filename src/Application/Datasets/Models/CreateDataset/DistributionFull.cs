namespace Application.Datasets.Models.CreateDataset;

public sealed record DistributionFull(
	int DistributionId,
	string AccessUrl,
	string Description,
	string Format,
	bool Availability);

