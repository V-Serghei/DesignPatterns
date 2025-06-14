namespace DesignPatterns.PROTOTYPE.Ex1;

public class Warrior: Character
{
    public string WeaponType { get; set; }

    public override ICharacter Clone()
    {
        // Deep copy implementation
        Warrior clone = (Warrior)this.MemberwiseClone();
            
        // Deep copy for reference types
        clone.Equipment = new List<string>(this.Equipment);
            
        return clone;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Weapon Type: {WeaponType}");
    }
}