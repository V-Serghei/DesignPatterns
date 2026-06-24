using DesignPatterns.PROTOTYPE.Ex1;

namespace DesignPatterns.Client.Prototype;

public class PrototypeClient
{
    public void Run()
    {
        var warriorPrototype = new Warrior
        {
            Health = 100, Strength = 15, Defense = 10,
            WeaponType = "Sword",
            Equipment = new List<string> { "Shield", "Helmet", "Chainmail" }
        };

        var archerPrototype = new Archer
        {
            Health = 80, Strength = 8, Defense = 5,
            RangeDistance = 100,
            Equipment = new List<string> { "Bow", "Quiver", "Leather Armor" }
        };

        var registry = new CharacterRegistry();
        registry.AddPrototype("warrior", warriorPrototype);
        registry.AddPrototype("archer", archerPrototype);

        var w1 = (Warrior)registry.GetClone("warrior");
        w1.Name = "Aragorn";

        var w2 = (Warrior)registry.GetClone("warrior");
        w2.Name = "Boromir";
        w2.Equipment.Add("Horn of Gondor");

        var a1 = (Archer)registry.GetClone("archer");
        a1.Name = "Legolas";
        a1.RangeDistance = 150;

        Console.WriteLine("--- Warrior 1 ---");
        w1.Display();
        Console.WriteLine("\n--- Warrior 2 ---");
        w2.Display();
        Console.WriteLine("\n--- Archer 1 ---");
        a1.Display();

        Console.WriteLine("\n--- Proving deep copy: clearing prototype equipment ---");
        warriorPrototype.Equipment.Clear();
        Console.WriteLine("Warrior 1 equipment (should be unchanged):");
        w1.Display();
    }
}
