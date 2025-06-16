namespace DesignPatterns.Facade.ex1;

public class Projector
{
    public void TurnOn() { Console.WriteLine("Проектор включен"); }
    public void TurnOff() { Console.WriteLine("Проектор выключен"); }
    public void SetInputDVD() { Console.WriteLine("Проектор переключен на вход DVD"); }
}