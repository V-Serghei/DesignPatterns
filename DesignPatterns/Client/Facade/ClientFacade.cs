using DesignPatterns.Facade.ex1;

namespace DesignPatterns.Client.Facade;

public class ClientFacade
{
    public void Run()
    {
        DVDPlayer dvdPlayer = new DVDPlayer();
        Amplifier amplifier = new Amplifier();
        Projector projector = new Projector();
        Lights lights = new Lights();
        Screen screen = new Screen();
        
        // Создаем фасад
        HomeTheaterFacade homeTheater = new HomeTheaterFacade(
            dvdPlayer, amplifier, projector, lights, screen
        );
        
        // Используем фасад для простого управления сложной системой
        homeTheater.WatchMovie("Матрица");
        
        Console.WriteLine("\nНаслаждаемся фильмом...\n");
        
        homeTheater.EndMovie();
    }
}