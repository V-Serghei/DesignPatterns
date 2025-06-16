namespace DesignPatterns.State.ex2;

public class BookContext
{
    private IBookState _state;
    
    
    public BookContext(IBookState initialState)
    {
        _state = initialState;
    }

    public void SetState(IBookState state)
    {
        _state = state;
    }

    public void Open()
    {
        _state.Open(this);
    }

    public void Close()
    {
        _state.Close(this);
    }

    public void Write(string content)
    {
        _state.Write(this, content);
    }

    public void Edit(string content)
    {
        _state.Edit(this, content);
    }

    public void Read(string content)
    {
        _state.Read(this, content);
    }

    public void Archive()
    {
        _state.Archive(this);
    }

    public void Delete()
    {
        _state.Delete(this);
    }
}