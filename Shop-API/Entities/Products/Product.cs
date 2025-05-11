using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop_API.Entities.SalesUnits;
using Shop_API.Entities.Subcategories;
using Shop_API.Entities.Thicknesses;

namespace Shop_API.Entities.Products;

public class Product
{
    [Key] public int Id { get; set; }

    [Required] public string Name { get; set; }

    [Required] public string Code { get; set; }

    public List<string> ImageUrls { get; set; }

    public List<byte[]> ImageFiles { get; set; }

    public string Color { get; set; }

    public string Model { get; set; }

    public string Brand { get; set; }

    public string Material { get; set; }

    // Many-to-many relationship with Thickness
    public List<Thickness> Thicknesses { get; set; }

    // Many-to-one relationship with SalesUnit
    public int? SalesUnitId { get; set; }
    public SalesUnit SalesUnit { get; set; }

    [Column(TypeName = "decimal(18,3)")] public decimal? Width { get; set; }

    [Column(TypeName = "decimal(18,3)")] public decimal? Length { get; set; }

    [Column(TypeName = "decimal(18,3)")] public decimal? Area { get; set; }

    public string Description { get; set; }

    [Column(TypeName = "decimal(18,0)")] public decimal Price { get; set; }

    [Column(TypeName = "decimal(3,1)")] public decimal Discount { get; set; }

    [Column(TypeName = "decimal(18,0)")] public decimal DiscountedPrice { get; set; }

    public float Quantity { get; set; }

    [Required] public string InStock { get; set; }

    // Many-to-one relationship with SubCategory
    public int SubCategoryId { get; set; }
    public Subcategory SubCategory { get; set; }

    // Soft delete
    public DateTime? DeletedDate { get; set; }


    // Calculations for discount and area
    public void CalculateDiscountedPrice()
    {
        if (Discount > 0)
        {
            DiscountedPrice = Price - (Price * (Discount / 100));
        }
        else
        {
            DiscountedPrice = Price;
        }
    }

    public void CalculateArea()
    {
        if (Width.HasValue && Length.HasValue)
        {
            Area = Width.Value * Length.Value;
        }
        else
        {
            Area = 0;
        }
    }

    public void UpdateStatus()
    {
        if (Quantity <= 0)
        {
            InStock = "ناموجود";
        }
        else
        {
            InStock = "موجود";
        }
    }

    public void SetDefaultQuantity()
    {
        if (Quantity == null)
        {
            Quantity = 0;
        }
    }

    // Action to be called before insert/update
    public void BeforeInsert()
    {
        if (string.IsNullOrWhiteSpace(Code))
        {
            Code = null;
        }

        SetDefaultQuantity();
        CalculateArea();
        CalculateDiscountedPrice();
        UpdateStatus();
    }

    public void BeforeUpdate()
    {
        SetDefaultQuantity();
        CalculateArea();
        CalculateDiscountedPrice();
        UpdateStatus();
    }
}