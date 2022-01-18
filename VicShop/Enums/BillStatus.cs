using System.ComponentModel;

namespace VicShop.Enums;

public enum BillStatus
{
    [Description("Tạo mới")]
    New,
    [Description("Đang xử lý")]
    InProgress,
    [Description("Trả lại")]
    Returned,
    [Description("Hủy bỏ")]
    Cancelled,
    [Description("Hoàn thành")]
    Completed
}