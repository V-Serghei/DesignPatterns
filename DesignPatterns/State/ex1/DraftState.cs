namespace DesignPatterns.State.ex1;


/// <summary>
/// Представлено конкретное состояние документа - черновик.
/// </summary>
public class DraftState: IDocumentState
{
    public void Edit(DocumentContext document, string content)
    {
        document.UpdateContent(content);
    }

    public void Review(DocumentContext document)
    {
        Console.WriteLine("Sending document for review");
        document.ChangeState(new ModerationState());
    }

    public void Publish(DocumentContext document)
    {
        Console.WriteLine("Cannot publish from Draft state - document must be reviewed first");
    }

    public void Archive(DocumentContext document)
    {
        Console.WriteLine("Archiving draft document");
        document.ChangeState(new ArchivedState());
    }

    public string GetStateName() => "Draft";
}
