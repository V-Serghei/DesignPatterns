namespace DesignPatterns.Mediator.ex1;

public abstract class ContentEditorMediatorAbstract
{
    protected List<IEditorComponent> components = new List<IEditorComponent>();

    public void RegisterComponent(IEditorComponent component)
    {
        components.Add(component);
        component.SetMediator(this);
    }

    public abstract void HandleEvent(string eventType, IEditorComponent sender, object data);
}