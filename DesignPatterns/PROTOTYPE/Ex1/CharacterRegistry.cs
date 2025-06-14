namespace DesignPatterns.PROTOTYPE.Ex1;

public class CharacterRegistry
{
    private Dictionary<string, ICharacter> _prototypes = new Dictionary<string, ICharacter>();

    public void AddPrototype(string key, ICharacter prototype)
    {
        _prototypes[key] = prototype;
    }

    public ICharacter GetClone(string key)
    {
        if (!_prototypes.ContainsKey(key))
        {
            throw new ArgumentException($"Prototype with key '{key}' doesn't exist");
        }
            
        return _prototypes[key].Clone();
    }
}