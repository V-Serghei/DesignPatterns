namespace DesignPatterns.ADAPTER.ex2;

public class ThermometerAdapter: ISmartSensor
{
    private AnalogThermometer _thermometer;

    public ThermometerAdapter(AnalogThermometer thermometer)
    {
        _thermometer = thermometer;
    }

    public double GetTemperatureInCelsius()
    {
        int mercuryLevel = _thermometer.ReadMercuryLevel();
        // Преобразование уровня ртути в температуру (примерная формула)
        double temperature = (mercuryLevel / 100.0) * 50 - 10; // Диапазон от -10 до 40°C
        Console.WriteLine($"ThermometerAdapter: Преобразование уровня ртути {mercuryLevel} в температуру {temperature}°C");
        return temperature;
    }

    public string GetSensorStatus()
    {
        return _thermometer.CheckMechanicalCondition();
    }
}