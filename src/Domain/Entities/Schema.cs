namespace Domain.Entities;

public class Schema
{
    public int Id { get; set; }
    public string Name { get; set; } = default!; 
    public string JsonSchema { get; set; } = default!;
    public List<DataSet> DataSets { get; set; } = default!;
    public Schema(string name, string jsonSchema)
    {
        Name = name;
        JsonSchema = jsonSchema;
    }
}