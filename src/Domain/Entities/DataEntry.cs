namespace Domain.Entities;

public sealed class DataEntry
{
	public int Id { get; set; }

	public int DatasetId { get; set; }

	public DataSet? DataSet { get; set; }

	public string Data { get; set; } = default!;
}
