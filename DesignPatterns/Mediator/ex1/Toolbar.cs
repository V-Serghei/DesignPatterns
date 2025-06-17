namespace DesignPatterns.Mediator.ex1;

public class Toolbar: IEditorComponent
{
    private ContentEditorMediatorAbstract mediator;

    public void SetMediator(ContentEditorMediatorAbstract mediator) => this.mediator = mediator;
    public void Notify(string eventType, object data)
    {
        throw new NotImplementedException();
    }

    public void Save() => mediator.HandleEvent("SaveClicked", this, null);
    public void Publish() => mediator.HandleEvent("PublishClicked", this, null);
    public void Cancel() => mediator.HandleEvent("CancelClicked", this, null);
}