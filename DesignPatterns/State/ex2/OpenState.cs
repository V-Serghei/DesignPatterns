namespace DesignPatterns.State.ex2;

public class OpenState : IBookState
{
    public void Open(BookContext book)
    {
        Console.WriteLine("The book is already open.");
    }

    public void Close(BookContext book)
    {
        Console.WriteLine("Closing the book.");
        book.SetState(new ClosedState());
    }

    public void Write(BookContext book, string content)
    {
        Console.WriteLine($"Writing content to the book: {content}");
    }

    public void Edit(BookContext book, string content)
    {
        Console.WriteLine($"Editing content in the book: {content}");
    }

    public void Read(BookContext book, string content)
    {
        Console.WriteLine($"Reading content from the book: {content}");
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