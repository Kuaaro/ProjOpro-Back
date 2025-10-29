namespace Domain.Entities;

public sealed class Catalog
{
	public int Id { get; set; }

	public string Name { get; set; } = default!;

	public string? Description { get; set; }

	
	public int ParentId { get; set; }

	public Catalog? Parent { get; set; }

	public List<Catalog> Children { get; set; } = [];

	public List<DataSet> DataSets { get; set; } = [];
}