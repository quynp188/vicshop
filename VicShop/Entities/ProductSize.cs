using System.ComponentModel.DataAnnotations.Schema;

namespace VicShop.Entities;

public class ProductSize
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int SizeId { set; get; }

    [ForeignKey("ProductId")]
    public virtual Product Product { set; get; }

    [ForeignKey("SizeId")]
    public virtual Size Size { set; get; }
}