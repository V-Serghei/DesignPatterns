namespace DesignPatterns.Decorator.ex2;

public abstract class GenereteProcedurOnline: IGenerete
{
    private readonly IGenerete _component;
    
    public GenereteProcedurOnline(IGenerete component)
    {
        _component = component;
    }
    
    public virtual void GenerateProcedure()
    {
        _component.GenerateProcedure();
    }

    public void GenerateReport()
    {
        _component.GenerateProcedure();
    }

    public void GenterateDocumentation()
    {
        _component.GenterateDocumentation();
    }
}