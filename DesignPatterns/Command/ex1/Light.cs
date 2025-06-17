namespace DesignPatterns.Command.ex1;

public class Light
{
    private readonly string _location;
    private int _intensity;
    private bool _isOn;

    public Light(string location)
    {
        _location = location;
        _intensity = 100;
        _isOn = false;
    }

    public void TurnOn()
    {
        _isOn = true;
        Console.WriteLine($"{_location} light is now ON at {_intensity}% brightness");
    }

    public void TurnOff()
    {
        _isOn = false;
        Console.WriteLine($"{_location} light is now OFF");
    }

    public void SetIntensity(int intensity)
    {
        _intensity = Math.Clamp(intensity, 0, 100);
        if (_isOn)
        {
            Console.WriteLine($"{_location} light intensity set to {_intensity}%");
        }
    }

    public override string ToString() => $"{_location} Light";
}