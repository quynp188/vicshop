using System.ComponentModel.DataAnnotations.Schema;

namespace VicShop.Entities;

public class ProductColor
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ColorId { set; get; }

    [ForeignKey("ProductId")]
    public virtual Product Product { set; get; }

    [ForeignKey("ColorId")]
    public virtual Color Color { set; get; }
}