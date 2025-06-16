namespace DesignPatterns.State.ex1;



public class DocumentContext
{
    private IDocumentState _state;
    public string Content { get; private set; }
    public string Name { get; }
    
    
    /// <summary>
    /// Класс контекста
    /// Определяет класс, предоставляющий клиентам интерфейс для управления состоянием документа.
    /// Хранит экземляр текущего состояния
    /// </summary>
    /// <param name="name"></param>
    public DocumentContext(string name)
    {
        Name = name;
        Content = string.Empty;
        _state = new DraftState(); 
        Console.WriteLine($"Document '{Name}' created in state: {_state.GetStateName()}");
    }
    
    public void ChangeState(IDocumentState newState)
    {
        _state = newState;
        Console.WriteLine($"Document '{Name}' state changed to: {_state.GetStateName()}");
    }
    
    public void Edit(string content)
    {
        _state.Edit(this, content);
    }
    public void Review()
    {
        _state.Review(this);
    }
    
    public void Publish()
    {
        _state.Publish(this);
    }
    
    public void Archive()
    {
        _state.Archive(this);
    }
    
    
    public void UpdateContent(string content)
    {
        Content = content;
        Console.WriteLine($"Document '{Name}' content updated: {Content}");
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Document Name: {Name}");
        Console.WriteLine($"Current State: {_state.GetStateName()}");
        Console.WriteLine($"Content: {Content}");
        Console.WriteLine();
    }
    
}