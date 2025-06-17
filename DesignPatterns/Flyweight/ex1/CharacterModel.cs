namespace DesignPatterns.Flyweight.ex1;

public class CharacterModel:IFlyweight
{
    // Внутреннее состояние (shared)
    public string ModelName { get; }
    public int PolygonCount { get; }
    public string TexturePath { get; }

    public CharacterModel(string modelName, int polygonCount, string texturePath)
    {
        ModelName = modelName;
        PolygonCount = polygonCount;
        TexturePath = texturePath;
        Console.WriteLine($"LOADING MODEL: {modelName} with {polygonCount} polygons and texture: {texturePath}");
    }

    public void Render(float x, float y, float z, string animation)
    {
        Console.WriteLine($"Rendering {ModelName} at ({x}, {y}, {z}) with animation '{animation}'");
    }
}