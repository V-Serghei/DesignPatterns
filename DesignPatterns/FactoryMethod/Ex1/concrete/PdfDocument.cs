using System.Diagnostics;
using DesignPatterns.FactoryMethod.Ex1.abstracts;

namespace DesignPatterns.FactoryMethod.Ex1.concrete;

/// <summary>
/// конкретный создатель, определяет какой продукт будет создан
///
/// </summary>
public class PdfDocument : Document
{
    public PdfDocument(string fileName) : base(fileName) { }
    /// <summary>
    /// Тот самый метод, который будет создавать конкретный продукт
    /// </summary>
    /// <returns>конкретный продукт PdfProcessor</returns>
    protected override IDocumentProcessor CreateProcessor()
    {
        return new PdfProcessor();
    }
    
}