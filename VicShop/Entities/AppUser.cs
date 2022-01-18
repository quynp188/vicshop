using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using VicShop.Enums;

namespace VicShop.Entities;

[Table("AppUsers")]
public class AppUser: IdentityUser<string>
{
    [Required]
    public string FullName { get; set; }
    public string? Avatar { get; set; }
    [Required]
    public string Address { get; set; }
    public string? DepartmentId { get; set; }
    public Gender Gender { get; set; }
    public DateTime? BirthDay { set; get; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}