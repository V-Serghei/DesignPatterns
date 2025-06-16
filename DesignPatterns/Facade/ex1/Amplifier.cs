namespace DesignPatterns.Facade.ex1;

public class Amplifier
{
    public void TurnOn() { Console.WriteLine("Усилитель включен"); }
    public void TurnOff() { Console.WriteLine("Усилитель выключен"); }
    public void SetVolume(int level) { Console.WriteLine($"Громкость установлена на {level}"); }
    public void SetSurroundSound() { Console.WriteLine("Режим объемного звука включен"); }
}