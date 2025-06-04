using DesignPatterns.FactoryMethod.Ex1.abstracts;

namespace DesignPatterns.FactoryMethod.Ex1.concrete;


/// <summary>
/// Конкретный продукт, реализующий интерфейс IDocumentProcessor
/// </summary>
public class WordProcessor:IDocumentProcessor
{
    public void Open(Document document)
    {
        Console.WriteLine($"Opening Word document: {document.FileName}");
    }

    public void Extract()
    {
        Console.WriteLine("Extracting text from Word document.");
    }

    public void Analyze()
    {
        Console.WriteLine("Analyzing Word document structure.");
    }

    public void Save(string filePath)
    {
        Console.WriteLine($"Saving Word document to:\\ {filePath}");
    }

    public void Close()
    {
        Console.WriteLine("Closing Word document.");
    }
}