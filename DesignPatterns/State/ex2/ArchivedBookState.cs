namespace DesignPatterns.State.ex2;

public class ArchivedBookState : IBookState
{
    public void Open(BookContext book)
    {
        Console.WriteLine("Cannot open an archived book. Please restore it first.");
    }

    public void Close(BookContext book)
    {
        Console.WriteLine("Cannot close an archived book. It is already archived.");
    }

    public void Write(BookContext book, string content)
    {
        Console.WriteLine("Cannot write to an archived book. Please restore it first.");
    }

    public void Edit(BookContext book, string content)
    {
        Console.WriteLine("Cannot edit an archived book. Please restore it first.");
    }

    public void Read(BookContext book, string content)
    {
        Console.WriteLine("Cannot read an archived book. Please restore it first.");
    }

    public void Archive(BookContext book)
    {
        Console.WriteLine("The book is already archived.");
    }

    public void Delete(BookContext book)
    {
        Console.WriteLine("Deleting the archived book.");
        book.SetState(new DeletedState());
    }
}