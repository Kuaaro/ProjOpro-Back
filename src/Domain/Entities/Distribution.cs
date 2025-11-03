namespace Domain.Entities;

public sealed class Distribution
{
	public int Id { get; set; }
	
	public string? Description { get; set; }

	public bool IsAvailable { get; set; }

	public string? Format { get; set; }
	
	public DataSet DataSet { get; set; }
}