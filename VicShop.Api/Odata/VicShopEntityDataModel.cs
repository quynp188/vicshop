using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
namespace VicShop.Api.Odata;

public static class VicShopEntityDataModel
{
    public static IEdmModel GetEdmModel()
    {
        var builder = new ODataConventionModelBuilder {
            Namespace = "MsShop.Api",
            ContainerName = "MsShop.Api.Container"
        };

        builder.EntitySet<Product>("Product");
        var edmModel = builder.GetEdmModel();
        return edmModel;
    }
}