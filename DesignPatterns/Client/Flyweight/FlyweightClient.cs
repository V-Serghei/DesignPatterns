using DesignPatterns.Flyweight.ex1;

namespace DesignPatterns.Client.Flyweight;

public class FlyweightClient
{
    public void Run()
    {
        // Создание фабрики приспособленцев
        var modelFactory = new CharacterModelFactory();

        // Создание списка персонажей и отрядов
        var characters = new List<GameCharacter>();
        var squads = new List<IFlyweight>();

        Console.WriteLine("===== Creating characters and squads =====");

        // Создание отдельных персонажей
        characters.Add(new GameCharacter("Player1", "soldier", 10, 0, 10, modelFactory));
        characters.Add(new GameCharacter("Player2", "archer", 20, 0, 20, modelFactory));
        characters.Add(new GameCharacter("Player3", "mage", 15, 0, 30, modelFactory));
        characters.Add(new GameCharacter("Player4", "soldier", 30, 0, 10, modelFactory)); // Reuse soldier
        characters.Add(new GameCharacter("Player5", "archer", 40, 0, 20, modelFactory));  // Reuse archer

        // Создание отряда (неразделяемый приспособленец)
        var squad = modelFactory.CreateSquad("AlphaSquad", new List<string> { "soldier", "archer", "mage" });
        squads.Add(squad);

        Console.WriteLine("\n===== Rendering game frame =====");

        // Движение и атака некоторых персонажей
        characters[0].MoveTo(12, 0, 12);
        characters[2].Attack();

        // Рендеринг всех персонажей
        foreach (var character in characters)
        {
            character.Render();
            Console.WriteLine();
        }

        // Рендеринг отряда
        squads[0].Render(25, 0, 25, "marching");

        // Показ статистики
        Console.WriteLine($"\nTotal characters/squads: {characters.Count + squads.Count}");
        Console.WriteLine($"Total flyweight models loaded: {modelFactory.GetLoadedFlyweightCount()}");
        Console.WriteLine($"Memory saved: {characters.Count + squads.Count - modelFactory.GetLoadedFlyweightCount()} objects");
    }
    
}