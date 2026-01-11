namespace Domain.Entities;

public sealed class SensorRouter
{
	public int Id { get; set; }

	public int SensorId { get; set; }

	public int DatasetId { get; set; }
}
