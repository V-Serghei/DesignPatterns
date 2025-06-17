namespace DesignPatterns.Mediator.ex1;

public interface IEditorComponent
{
    void SetMediator(ContentEditorMediatorAbstract mediator);
    void Notify(string eventType, object data);
}