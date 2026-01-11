using Application.Sensors.Models.CreateSensorRouter;
using Application.Sensors.Models.SendSensorData;
using Domain.Entities;
using Domain.Repositories;
using Json.Schema;
using System.Text.Json;

namespace Application.Sensors;

internal sealed class SensorService(
	ISensorRouterRepository sensorRouterRepository,
	IDatasetRepository datasetRepository,
	ISchemaRepository schemaRepository,
	IDataEntryRepository dataEntryRepository) : ISensorService
{
	public async Task<CreateSensorRouterResponse> CreateSensorRouter(CreateSensorRouterRequest request)
	{
		Console.WriteLine($"Creating SensorRouter: SensorId={request.SensorId}, DatasetId={request.DatasetId}");
		
		var sensorRouter = new SensorRouter
		{
			SensorId = request.SensorId,
			DatasetId = request.DatasetId
		};

		sensorRouterRepository.Add(sensorRouter);
		await sensorRouterRepository.SaveChanges();

		Console.WriteLine($"SensorRouter created with Id={sensorRouter.Id}");
		return new CreateSensorRouterResponse(sensorRouter.Id);
	}

	public async Task SendSensorData(SendSensorDataRequest request)
	{
		Console.WriteLine($"Sensor data received: SensorId={request.SensorId}");

		var sensorRouters = await sensorRouterRepository.GetBySensorId(request.SensorId);
		Console.WriteLine($"Found {sensorRouters.Count} router(s) for SensorId={request.SensorId}");

		foreach (var sensorRouter in sensorRouters)
		{
			var dataset = await datasetRepository.GetById(sensorRouter.DatasetId);
			if (dataset is null)
			{
				Console.WriteLine($"Dataset with id {sensorRouter.DatasetId} not found");
				continue;
			}

			var schema = await schemaRepository.GetById(dataset.SchemaId);
			if (schema is null)
			{
				Console.WriteLine($"Schema with id {dataset.SchemaId} not found");
				continue;
			}

			Console.WriteLine($"Schema loaded for DatasetId={dataset.Id}, SchemaId={schema.Id}");

			using var schemaDoc = JsonDocument.Parse(schema.JsonSchema);
			var jsonSchema = JsonSchema.Build(schemaDoc.RootElement);
			using var dataDoc = JsonDocument.Parse(request.Data);
			var evaluationResult = jsonSchema.Evaluate(dataDoc.RootElement);

			if (evaluationResult.IsValid)
			{
				var dataEntry = new DataEntry
				{
					DatasetId = dataset.Id,
					Data = request.Data
				};

				dataEntryRepository.Add(dataEntry);
				Console.WriteLine($"Data saved successfully for DatasetId={dataset.Id}");
			}
			else
			{
				Console.WriteLine($"Validation failed for DatasetId={dataset.Id}");
			}
		}

		await dataEntryRepository.SaveChanges();
	}
}
