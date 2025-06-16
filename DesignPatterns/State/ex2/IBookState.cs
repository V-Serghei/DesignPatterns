namespace DesignPatterns.State.ex2;

public interface IBookState
{
    void Open(BookContext book);
    void Close(BookContext book);
    void Write(BookContext book, string content);
    void Edit(BookContext book, string content);
    void Read(BookContext book, string content);
    void Archive(BookContext book);
    void Delete(BookContext book);
    
}