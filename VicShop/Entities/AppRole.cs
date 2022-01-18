using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace VicShop.Entities;

[Table("AppRoles")]
public class AppRole: IdentityRole<string>
{
    [StringLength(250)]
    public string? Description { get; set; }
}