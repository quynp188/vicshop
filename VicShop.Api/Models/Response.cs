namespace VicShop.Api.Models;

public class Response
{
    public string Message { get; set; }
    public object Data { get; set; }
    public string Token { get; set; }
    public Response(string message)
    {
        this.Message = message;
    }
    public Response(string message,string token)
    {
        this.Message = message;
        this.Token = token;
    }     
    public Response(string status, string message, object data)
    {
        this.Message = message;
        this.Data = data;
    }
}