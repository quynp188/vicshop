using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VicShop.Entities;

[Table("Categories")]
public class Category
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int? ParentId { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<Product>? Products { set; get; }
}