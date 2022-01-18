using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using VicShop.EF;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VicShop.Api.Controllers;

[Route("odata")]
public class ProductController : ODataController
{
    private readonly IRepository<Product, int> _productRepository;

    public ProductController(IRepository<Product,int> productRepository)
    {
        this._productRepository = productRepository;
    }
    [EnableQuery]
    [HttpGet("products")]
    public IActionResult Get()
    {
        var product = _productRepository.FindAll();
        return (IActionResult)Ok(product);
    }
}