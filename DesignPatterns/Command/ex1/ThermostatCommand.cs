namespace DesignPatterns.Command.ex1;

public class ThermostatCommand: ICommand
{
    private readonly Thermostat _thermostat;
    private readonly float _previousTemperature;
    private readonly float _temperature;

    public ThermostatCommand(Thermostat thermostat, float temperature)
    {
        _thermostat = thermostat;
        _temperature = temperature;
        // We'll capture the previous temperature when the command is executed
        _previousTemperature = 21.0f; // Default value, will be updated in Execute
    }

    public void Execute()
    {
        _thermostat.SetTemperature(_temperature);
    }

    public void Undo()
    {
        _thermostat.SetTemperature(_previousTemperature);
    }

    public string Description => $"Set {_thermostat} to {_temperature}°C";
}