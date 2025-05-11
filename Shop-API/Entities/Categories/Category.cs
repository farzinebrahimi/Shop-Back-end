using Shop_API.Entities.Subcategories;

namespace Shop_API.Entities.Categories;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    // One-to-many relationship with SubCategory
    public List<Subcategory> SubCategories { get; set; }
}