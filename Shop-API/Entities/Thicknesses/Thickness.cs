using Shop_API.Entities.Products;

namespace Shop_API.Entities.Thicknesses;

public class Thickness
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Many-to-many relationship with Product
    public List<Product> Products { get; set; }
}