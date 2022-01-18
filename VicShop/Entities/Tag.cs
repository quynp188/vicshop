using System.ComponentModel.DataAnnotations;

namespace VicShop.Entities;

public class Tag
{
    public int Id { get; set; }
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }
}