namespace Domain.Entities;

public class Schema
{
	public int Id { get; set; }

	public string JsonSchema { get; set; } = default!;

	public List<DataSet> DataSets { get; set; } = default!;
}