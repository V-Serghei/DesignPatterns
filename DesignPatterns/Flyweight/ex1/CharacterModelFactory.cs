namespace DesignPatterns.Flyweight.ex1;

public class CharacterModelFactory
{
    private Dictionary<string, IFlyweight> flyweights = new Dictionary<string, IFlyweight>();

    public IFlyweight GetFlyweight(string modelType)
    {
        if (flyweights.ContainsKey(modelType))
        {
            Console.WriteLine($"Reusing existing model: {modelType}");
            return flyweights[modelType];
        }

        IFlyweight flyweight = modelType switch
        {
            "soldier" => new CharacterModel("Soldier", 5000, "soldier_texture.png"),
            "archer" => new CharacterModel("Archer", 4500, "archer_texture.png"),
            "mage" => new CharacterModel("Mage", 4200, "mage_texture.png"),
            _ => throw new ArgumentException($"Unknown model type: {modelType}")
        };

        flyweights[modelType] = flyweight;
        return flyweight;
    }

    public IFlyweight CreateSquad(string squadName, List<string> memberTypes)
    {
        var members = memberTypes.Select(type => GetFlyweight(type)).ToList();
        var squad = new CharacterSquad(squadName, members);
        return squad;
    }

    public int GetLoadedFlyweightCount() => flyweights.Count;
}