namespace DesignPatterns.ADAPTER.ex2;

public class SmartHomeSystem
{
    private ISmartSensor _sensor;

    public SmartHomeSystem(ISmartSensor sensor)
    {
        _sensor = sensor;
    }

    public void MonitorEnvironment()
    {
        double temperature = _sensor.GetTemperatureInCelsius();
        string status = _sensor.GetSensorStatus();
        Console.WriteLine($"SmartHomeSystem: Температура: {temperature}°C, Статус: {status}");
        if (temperature > 30)
        {
            Console.WriteLine("SmartHomeSystem: Активация охлаждения!");
        }
    }
}