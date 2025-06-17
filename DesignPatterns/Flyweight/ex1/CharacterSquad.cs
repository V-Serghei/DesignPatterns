namespace DesignPatterns.Flyweight.ex1;

public class CharacterSquad: IFlyweight
{
    private List<IFlyweight> members = new List<IFlyweight>();
    private string squadName;

    public CharacterSquad(string squadName, List<IFlyweight> members)
    {
        this.squadName = squadName;
        this.members = members;
        Console.WriteLine($"CREATING SQUAD: {squadName} with {members.Count} members");
    }

    public void Render(float x, float y, float z, string animation)
    {
        Console.WriteLine($"Rendering squad {squadName} at ({x}, {y}, {z}) with animation '{animation}'");
        foreach (var member in members)
        {
            member.Render(x, y, z, animation);
        }
    }
}