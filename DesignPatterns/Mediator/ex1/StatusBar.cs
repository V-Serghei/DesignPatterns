namespace DesignPatterns.Mediator.ex1;

public class StatusBar: IEditorComponent
{
    private ContentEditorMediatorAbstract mediator;

    public void SetMediator(ContentEditorMediatorAbstract mediator) => this.mediator = mediator;

    public void Notify(string eventType, object data)
    {
        if (eventType == "ShowMessage")
            Console.WriteLine($"Status: {data}");
    }
}