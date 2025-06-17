namespace DesignPatterns.Mediator.ex1;

public class PreviewPanel: IEditorComponent
{
    private ContentEditorMediatorAbstract mediator;

    public void SetMediator(ContentEditorMediatorAbstract mediator) => this.mediator = mediator;

    public void Notify(string eventType, object data)
    {
        if (eventType == "UpdatePreview")
            Console.WriteLine($"Preview updated: {data}");
        else if (eventType == "ClearPreview")
            Console.WriteLine("Preview cleared.");
    }
}