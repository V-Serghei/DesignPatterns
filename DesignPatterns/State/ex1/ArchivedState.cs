namespace DesignPatterns.State.ex1;



/// <summary>
/// Конкретное состояние документа - Архивированное
/// 
/// </summary>
public class ArchivedState: IDocumentState
{
    public void Edit(DocumentContext document, string content)
    {
        Console.WriteLine("Cannot edit archived document - restore from archive first");
    }

    public void Review(DocumentContext document)
    {
        Console.WriteLine("Cannot review archived document");
    }

    public void Publish(DocumentContext document)
    {
        Console.WriteLine("Cannot publish archived document");
    }

    public void Archive(DocumentContext document)
    {
        Console.WriteLine("Document is already archived");
    }

    public string GetStateName() => "Archived";
}