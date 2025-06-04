namespace DesignPatterns.FactoryMethod.Ex1.abstracts;


// базовый класс
public abstract class Document
{
    public string FileName { get; }

    protected Document(string fileName)
    {
        FileName = fileName;
    }

    
    //фабричный метод, который делегирует создание экземпляров наследникам
    protected abstract IDocumentProcessor CreateProcessor();


    //базовый метод, выполняющий какую-то работу
    public void Process()
    {
        Console.WriteLine($"Processing {FileName}....");
        IDocumentProcessor processor = CreateProcessor();
        processor.Open(this);
        processor.Extract();
        processor.Analyze();
        processor.Save(FileName);
        processor.Close();
        
        
    }
}