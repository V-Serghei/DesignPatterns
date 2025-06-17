namespace DesignPatterns.Mediator.ex1;

public class Product
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime LastModified { get; set; }
    public ProductStatus Status { get; set; }

    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Name) &&
               !string.IsNullOrWhiteSpace(Description) &&
               Price > 0 && Price <= 10000m; // Ограничение цены
    }
}