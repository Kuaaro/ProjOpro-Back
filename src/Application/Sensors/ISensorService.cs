using Application.Sensors.Models.CreateSensorRouter;
using Application.Sensors.Models.SendSensorData;

namespace Application.Sensors;

public interface ISensorService
{
	Task<CreateSensorRouterResponse> CreateSensorRouter(CreateSensorRouterRequest request);
	Task SendSensorData(SendSensorDataRequest request);
}
