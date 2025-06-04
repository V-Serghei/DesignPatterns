using DesignPatterns.FactoryMethod.Ex1.abstracts;

namespace DesignPatterns.FactoryMethod.Ex1.concrete;

/// <summary>
/// Конкретный создатель, определяет какой продукт будет создан
///
/// </summary>
public class WordDocument:Document
{
    public WordDocument(string fileName) : base(fileName) { }

    /// <summary>
    /// Тот самый метод, который будет создавать конкретный продукт
    /// </summary>
    /// <returns>конкретный продукт WordProcessor</returns>
    protected override IDocumentProcessor CreateProcessor()
    {
        return new WordProcessor();
    }
}