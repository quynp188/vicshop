using System.ComponentModel;

namespace VicShop.Enums;

public enum ProductStatus
{

    [Description("Đang bán")]
    Available,
    [Description("Hết hàng")]
    OutOfStock,
    [Description("Ngừng kinh doanh")]
    StopBusiness
}