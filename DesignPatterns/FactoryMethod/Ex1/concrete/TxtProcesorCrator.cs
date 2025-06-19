using DesignPatterns.FactoryMethod.Ex1.abstracts;

namespace DesignPatterns.FactoryMethod.Ex1.concrete;

public class TxtProcesorCrator : Document
{
    public TxtProcesorCrator(string fileName) : base(fileName)
    {
      
    }
    
    protected override IDocumentProcessor CreateProcessor()
    {
        return new TxtProcessor();
    }
}