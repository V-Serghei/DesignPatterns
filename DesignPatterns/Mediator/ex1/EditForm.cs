namespace DesignPatterns.Mediator.ex1;

public class EditForm: IEditorComponent
{
    private ContentEditorMediatorAbstract mediator;

    public void SetMediator(ContentEditorMediatorAbstract mediator) => this.mediator = mediator;

    public void Notify(string eventType, object data)
    {
        if (eventType == "ResetForm")
            Console.WriteLine("Form reset.");
    }

    public void UpdateContent(string content)
    {
        mediator.HandleEvent("ContentUpdated", this, content);
    }
}