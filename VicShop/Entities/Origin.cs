using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VicShop.Entities;

[Table("Origins")]
public class Origin
{
    public int Id { get; set; }
    [Required]
    [StringLength(250)]
    public string Name { get; set; }
    [Required]
    [StringLength(250)]
    public string Code { get; set; }
}