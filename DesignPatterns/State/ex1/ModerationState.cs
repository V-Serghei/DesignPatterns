namespace DesignPatterns.State.ex1;


/// <summary>
/// Конкретное состояние документа - на этапе модерации.
/// </summary>
public class ModerationState: IDocumentState
{
    public void Edit(DocumentContext document, string content)
    {
        Console.WriteLine("Cannot edit while in review - must return to draft first");
    }

    public void Review(DocumentContext document)
    {
        Console.WriteLine("Document is already under review");
    }

    public void Publish(DocumentContext document)
    {
        Console.WriteLine("Review passed - publishing document");
        document.ChangeState(new PublishedState());
    }

    public void Archive(DocumentContext document)
    {
        Console.WriteLine("Cannot archive from Moderation state");
    }

    public string GetStateName() => "Moderation";
}
