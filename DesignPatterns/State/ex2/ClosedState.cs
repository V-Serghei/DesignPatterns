namespace DesignPatterns.State.ex2;

public class ClosedState: IBookState
{
    public void Open(BookContext book)
    {
        Console.WriteLine("Opening the book.");
        book.SetState(new OpenState());
    }

    public void Close(BookContext book)
    {
        Console.WriteLine("The book is already closed.");
    }

    public void Write(BookContext book, string content)
    {
        Console.WriteLine("Cannot write to a closed book. Please open it first.");
    }
    

    public void Edit(BookContext book, string content)
    {
        Console.WriteLine("Cannot edit a closed book. Please open it first.");
    }

    public void Read(BookContext book, string content)
    {
        Console.WriteLine("Cannot read a closed book. Please open it first.");
    }

    public void Archive(BookContext book)
    {
        Console.WriteLine("Archiving the book.");
        book.SetState(new ArchivedBookState());
    }

    public void Delete(BookContext book)
    {
        Console.WriteLine("Deleting the book.");
        book.SetState(new DeletedState());
    }
}