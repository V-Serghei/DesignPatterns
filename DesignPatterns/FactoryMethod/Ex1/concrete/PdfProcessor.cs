using DesignPatterns.FactoryMethod.Ex1.abstracts;

namespace DesignPatterns.FactoryMethod.Ex1.concrete;


/// <summary>
/// Конкретный продукт, реализующий интерфейс IDocumentProcessor
/// </summary>
public class PdfProcessor: IDocumentProcessor
{
    public void Open(Document document)
    {
        Console.WriteLine($"Opening PDF document: {document.FileName}");
    }

    public void Extract()
    {
        Console.WriteLine("Extracting text from PDF document.");
    }

    public void Analyze()
    {
        Console.WriteLine("Analyzing PDF document structure.");
    }

    public void Save(string filePath)
    {
        Console.WriteLine($"Saving PDF document to:\\ {filePath}");
    }

    public void Close()
    {
        Console.WriteLine("Closing PDF document.");
    }
}