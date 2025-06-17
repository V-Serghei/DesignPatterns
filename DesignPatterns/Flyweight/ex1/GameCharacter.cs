namespace DesignPatterns.Flyweight.ex1;

public class GameCharacter
{
    private float _x, _y, _z;
    private string _playerName;
    private string _currentAnimation;
    private IFlyweight _flyweight;

    public GameCharacter(string playerName, string characterType, float x, float y, float z, CharacterModelFactory factory)
    {
        _playerName = playerName;
        _x = x;
        _y = y;
        _z = z;
        _currentAnimation = "idle";
        _flyweight = factory.GetFlyweight(characterType);
        Console.WriteLine($"CREATING CHARACTER: {playerName} with model {_flyweight.GetType().Name}");
    }

    public void MoveTo(float x, float y, float z)
    {
        _x = x;
        _y = y;
        _z = z;
        _currentAnimation = "walking";
    }

    public void Attack()
    {
        _currentAnimation = "attacking";
    }

    public void Render()
    {
        Console.WriteLine($"Player '{_playerName}' rendering...");
        _flyweight.Render(_x, _y, _z, _currentAnimation);
    }
}