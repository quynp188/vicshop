using System.ComponentModel.DataAnnotations;

namespace VicShop.Api.Models;

public class AccountLogin
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}