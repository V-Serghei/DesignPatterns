namespace DesignPatterns.FactoryMethod.Ex1.abstracts;


/// <summary>
/// Интерфейс продукта 
/// </summary>
public interface IDocumentProcessor
{
    void Open(Document document);
    void Extract();
    void Analyze();
    void Save(string filePath);
    void Close();
}