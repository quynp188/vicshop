using System.ComponentModel.DataAnnotations.Schema;

namespace VicShop.Entities;

public class ProductTag
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int TagId { set; get; }

    [ForeignKey("ProductId")]
    public virtual Product Product { set; get; }

    [ForeignKey("TagId")]
    public virtual Tag Tag { set; get; }
}