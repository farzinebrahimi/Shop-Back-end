using Shop_API.Entities.Categories;
using Shop_API.Entities.Products;

namespace Shop_API.Entities.Subcategories;

public class Subcategory
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Many-to-one relationship with Category
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    // One-to-many relationship with Product
    public List<Product> Products { get; set; }
}