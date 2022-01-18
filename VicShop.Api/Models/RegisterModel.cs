using System.ComponentModel.DataAnnotations;
using VicShop.Enums;

namespace VicShop.Api.Models;

public class RegisterModel
{
    [Required]
    public string FullName { get; set; }
    public string? Avatar { get; set; }
    [Required]
    public string Adress { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    public string? DepartmentId { get; set; }
    public Gender Gender { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? BirthDay { set; get; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}