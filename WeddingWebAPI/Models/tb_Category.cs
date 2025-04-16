using System;
using System.Collections.Generic;

namespace WeddingWebAPI.Models;

public partial class tb_Category
{
    public int CategoryID { get; set; }

    public string? CategoryName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<tb_Product> tb_Products { get; set; } = new List<tb_Product>();
}
