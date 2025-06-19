namespace DesignPatterns.Decorator.ex2;

public class GenerateProcedureAzureDecorator: GenereteProcedurOnline
{
    private readonly IGenerete _component;
    public GenerateProcedureAzureDecorator(IGenerete component) : base(component)
    {
        _component = component;
    }
    
    public override void GenerateProcedure()
    {
        base.GenerateProcedure();
        _component.GenerateProcedure();
        // Дополнительная логика для Azure
        Console.WriteLine("Generate Procedure Azure");
    }
    
    
}

