namespace Domain.Entities;

public class Schema
{
	public int Id { get; set; }

	public string JsonSchema { get; set; } = default!;


	public int DataSetId { get; set; }

	public DataSet DataSet { get; set; } = default!;
}