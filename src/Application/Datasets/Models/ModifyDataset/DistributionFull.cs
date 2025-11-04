namespace Application.Datasets.Models.ModifyDataset;

public sealed record DistributionFull(
	int DistributionId,
	string AccessUrl,
	string Description,
	string Format,
	bool Availability);

