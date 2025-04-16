using System;
using System.Collections.Generic;

namespace WeddingWebAPI.Models;

public partial class tb_Cart
{
    public int CartID { get; set; }

    public int? UserID { get; set; }

    public int? ProductID { get; set; }

    public int? Quantity { get; set; }

    public virtual tb_Product? Product { get; set; }

    public virtual tb_User? User { get; set; }
}
