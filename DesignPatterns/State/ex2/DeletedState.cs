namespace DesignPatterns.State.ex2;

public class DeletedState : IBookState
{
    public void Open(BookContext book)
    {
        throw new NotImplementedException("Cannot open a deleted book. It has been removed permanently.");
    }

    public void Close(BookContext book)
    {
        throw new NotImplementedException("Cannot close a deleted book. It has been removed permanently.");
    }

    public void Write(BookContext book, string content)
    {
        throw new NotImplementedException("Cannot write to a deleted book. It has been removed permanently.");
    }

    public void Edit(BookContext book, string content)
    {
        throw new NotImplementedException("Cannot edit a deleted book. It has been removed permanently.");
    }

    public void Read(BookContext book, string content)
    {
        throw new NotImplementedException("Cannot read a deleted book. It has been removed permanently.");
    }

    public void Archive(BookContext book)
    {
        throw new NotImplementedException("Cannot archive a deleted book. It has been removed permanently.");
    }

    public void Delete(BookContext book)
    {
        Console.WriteLine("The book is already deleted. No further action can be taken.");
    }
}