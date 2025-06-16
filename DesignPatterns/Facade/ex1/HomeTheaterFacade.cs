namespace DesignPatterns.Facade.ex1;

public class HomeTheaterFacade
{
    private DVDPlayer _dvdPlayer;
    private Amplifier _amplifier;
    private Projector _projector;
    private Lights _lights;
    private Screen _screen;

    public HomeTheaterFacade(
        DVDPlayer dvdPlayer,
        Amplifier amplifier,
        Projector projector,
        Lights lights,
        Screen screen)
    {
        _dvdPlayer = dvdPlayer;
        _amplifier = amplifier;
        _projector = projector;
        _lights = lights;
        _screen = screen;
    }

    // Упрощенный интерфейс для запуска фильма
    public void WatchMovie(string movie)
    {
        Console.WriteLine("Подготовка к просмотру фильма...");
        _lights.Dim(10);
        _screen.Down();
        _projector.TurnOn();
        _projector.SetInputDVD();
        _amplifier.TurnOn();
        _amplifier.SetSurroundSound();
        _amplifier.SetVolume(5);
        _dvdPlayer.TurnOn();
        _dvdPlayer.Play(movie);
    }

    // Упрощенный интерфейс для завершения просмотра
    public void EndMovie()
    {
        Console.WriteLine("Завершение просмотра фильма...");
        _dvdPlayer.Stop();
        _dvdPlayer.TurnOff();
        _amplifier.TurnOff();
        _projector.TurnOff();
        _screen.Up();
        _lights.BrightenUp();
    }
}