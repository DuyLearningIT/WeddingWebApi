using System;
using System.Collections.Generic;

namespace WeddingWebAPI.Models;

public partial class tb_Order
{
    public int OrderID { get; set; }

    public int? UserID { get; set; }

    public DateOnly? OrderDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? Status { get; set; }

    public virtual tb_User? User { get; set; }

    public virtual ICollection<tb_OrderDetail> tb_OrderDetails { get; set; } = new List<tb_OrderDetail>();

    public virtual ICollection<tb_Payment> tb_Payments { get; set; } = new List<tb_Payment>();
}
