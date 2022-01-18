namespace VicShop.Api.Models;

public class JsonWebTokenModel
{
    public string? SecretKey { get; set; }     
    public string? ValidIssuer { get; set; }
    public string? ValidAudience { get; set; }
    public double ExpireTime { get; set; }
}