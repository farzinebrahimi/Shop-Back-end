using System.ComponentModel.DataAnnotations.Schema;
using Shop_API.Entities.Users;

namespace Shop_API.Entities.Photos;

[Table("Photos")]
public class Photo
{
    public int Id { get; set; }
    public string Url { get; set; }
    public bool IsMain { get; set; }
    public string? PublicId { get; set; }
    
    //navigation properties
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;

}