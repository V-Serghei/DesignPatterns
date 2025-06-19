namespace DesignPatterns.Command.ex1;

public class LightOffCommand: ICommand
{
    private readonly Light _light;
   
    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute() => _light.TurnOff();
    

    public void Undo()
    {
        _light.TurnOn();
    }

    public string Description => $"Turn off {_light}";
}