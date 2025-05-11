using Shop_API.Entities.Products;

namespace Shop_API.Entities.SalesUnits;

public class SalesUnit
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Relationship with Product
    public List<Product> Products { get; set; }
}