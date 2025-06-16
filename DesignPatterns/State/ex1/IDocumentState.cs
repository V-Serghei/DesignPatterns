namespace DesignPatterns.State.ex1;


/// <summary>
/// создает интерфейс,
/// который заключает в себе поведение,
/// связанное с определенным состоянием объекта Context
/// </summary>
public interface IDocumentState
{
    void Edit(DocumentContext document, string content);
    void Review(DocumentContext document);
    void Publish(DocumentContext document);
    void Archive(DocumentContext document);
    string GetStateName();
}