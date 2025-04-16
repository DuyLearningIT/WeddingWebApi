using System;
using System.Collections.Generic;

namespace WeddingWebAPI.Models;

public partial class tb_OrderDetail
{
    public int OrderDetailID { get; set; }

    public int? OrderID { get; set; }

    public int? ProductID { get; set; }

    public int? Quantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public virtual tb_Order? Order { get; set; }

    public virtual tb_Product? Product { get; set; }
}
