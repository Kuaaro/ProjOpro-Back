namespace Domain.Entities;

public sealed class DataSet
{
	public int Id { get; set; }
	
	public string Name { get; set; } = default!;

	public string? Description { get; set; }

	public string? ContactPoint { get; set; }

	public int SchemaId { get; set; }
	
	public Schema? Schema { get; set; }

	public List<Distribution> Distribution { get; set; } = [];

	public List<string> Keywords { get; set; } = [];

	public int ParentId { get; set; }
}