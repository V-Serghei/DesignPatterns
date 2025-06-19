using DesignPatterns.FactoryMethod.Ex1.abstracts;

namespace DesignPatterns.FactoryMethod.Ex1.concrete;

public class TxtProcessor : IDocumentProcessor
{
    public void Open(Document document)
    {
        throw new NotImplementedException();
    }

    public void Extract()
    {
        throw new NotImplementedException();
    }

    public void Analyze()
    {
        throw new NotImplementedException();
    }

    public void Save(string filePath)
    {
        throw new NotImplementedException();
    }

    public void Close()
    {
        throw new NotImplementedException();
    }
}