namespace DesignPatterns.Command.ex1;

public class Thermostat
{
    private readonly string _location;
    private float _temperature;

    public Thermostat(string location)
    {
        _location = location;
        _temperature = 21.0f; // Default temperature in Celsius
    }

    public void SetTemperature(float temperature)
    {
        float previousTemp = _temperature;
        _temperature = temperature;
        Console.WriteLine($"{_location} thermostat set from {previousTemp}°C to {_temperature}°C");
    }

    public override string ToString() => $"{_location} Thermostat";
}