namespace DesignPatterns.PROTOTYPE.Ex1;

public abstract class Character : ICharacter
    {
    public string Name { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public List<string> Equipment { get; set; } = new List<string>();

    public abstract ICharacter Clone();

    public virtual void Display()
    {
        Console.WriteLine($"Name: {Name ?? "Unnamed"}");
        Console.WriteLine($"Health: {Health}");
        Console.WriteLine($"Strength: {Strength}");
        Console.WriteLine($"Defense: {Defense}");
        Console.WriteLine("Equipment:");
        foreach (var item in Equipment)
        {
            Console.WriteLine($"  - {item}");
        }
    }
}