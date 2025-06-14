namespace DesignPatterns.PROTOTYPE.Ex1;

public class Archer: Character
{
    public int RangeDistance { get; set; }

    public override ICharacter Clone()
    {
        // Deep copy implementation
        Archer clone = (Archer)this.MemberwiseClone();
            
        // Deep copy for reference types
        clone.Equipment = new List<string>(this.Equipment);
            
        return clone;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Range Distance: {RangeDistance}");
    }
}