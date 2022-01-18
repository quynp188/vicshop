using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VicShop.Enums;

namespace VicShop.Entities;

[Table("Products")]
public class Product
{
    public int Id { get; set; }
    [StringLength(255)]
    [Required]
    public string ProductName { get; set; }
    [Required]
    [StringLength(255)]
    public string ProductNumber { get; set; }
    public int CategoryId { get; set; }
    public string Image { get; set; }

    [StringLength(255)]
    public string Unit { get; set; }
    [Required]
    [DefaultValue(0)]
    public decimal Price { get; set; }
    public decimal? PromotionPrice { get; set; }
    public bool? HomeFlag { get; set; }
    public bool? SaleFlag { get; set; }
    public int? ViewCount { get; set; }
    public ProductStatus Status { set; get; }
    [ForeignKey("CategoryId")]
    public virtual Category Category { set; get; }
    public virtual ICollection<ProductImage> ProductImages { set; get; }
    public virtual ICollection<ProductTag> ProductTags { set; get; }
    public virtual ICollection<ProductSize> ProductSizes { set; get; }
    public virtual ICollection<ProductColor> ProductColors { set; get; }
    public virtual ICollection<ProductOrigin> ProductOrigins { set; get; }
}