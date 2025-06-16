namespace DesignPatterns.Facade.ex1;

public class DVDPlayer
{
    public void TurnOn() { Console.WriteLine("DVD-плеер включен"); }
    public void TurnOff() { Console.WriteLine("DVD-плеер выключен"); }
    public void Play(string movie) { Console.WriteLine($"Воспроизведение фильма: {movie}"); }
    public void Stop() { Console.WriteLine("Воспроизведение остановлено"); }
}