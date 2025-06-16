namespace DesignPatterns.Facade.ex1;

public class Lights
{
    public void Dim(int level) { Console.WriteLine($"Освещение приглушено до {level}%"); }
    public void BrightenUp() { Console.WriteLine("Освещение восстановлено до 100%"); }
}