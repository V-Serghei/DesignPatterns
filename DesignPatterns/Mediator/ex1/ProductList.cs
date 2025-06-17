namespace DesignPatterns.Mediator.ex1;

public class ProductList: IEditorComponent
{
    private ContentEditorMediatorAbstract mediator;
    private List<object> products = new List<object>();

    public void SetMediator(ContentEditorMediatorAbstract mediator) => this.mediator = mediator;

    public void Notify(string eventType, object data)
    {
        if (eventType == "AddProduct")
            products.Add(data);
        else if (eventType == "PublishProduct")
            Console.WriteLine($"Published: {data}");
        Console.WriteLine($"Product list has {products.Count} items.");
    }
}