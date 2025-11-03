namespace Domain.Entities;

public sealed class Catalog
{
	public int Id { get; set; }

	public string Name { get; set; } = default!;

	public string Description { get; set; } = default!;
	
	public int ParentId { get; set; }

	public Catalog? Parent { get; set; }

	public List<Catalog> Children { get; set; } = [];

	public List<DataSet> DataSets { get; set; } = [];
	
	private Catalog(){}
	
	public Catalog (string name, string description, int parentId)
	{
		Name = name;
		Description = description;
		ParentId = parentId;
	}
}