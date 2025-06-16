namespace DesignPatterns.State.ex1;


/// <summary>
/// Кокретное состояние документа - опубликованный
/// </summary>
public class PublishedState: IDocumentState
{
    public void Edit(DocumentContext document, string content)
    {
        Console.WriteLine("Creating new draft from published document");
        document.UpdateContent(content);
        document.ChangeState(new DraftState());
    }

    public void Review(DocumentContext document)
    {
        Console.WriteLine("Document is already published - no need for review");
    }

    public void Publish(DocumentContext document)
    {
        Console.WriteLine("Document is already published");
    }

    public void Archive(DocumentContext document)
    {
        Console.WriteLine("Archiving published document");
        document.ChangeState(new ArchivedState());
    }

    public string GetStateName() => "Published";
}