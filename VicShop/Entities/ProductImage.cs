using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VicShop.Entities;

[Table("ProductImages")]
public class ProductImage
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    [StringLength(500)]
    public string? Path { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
}