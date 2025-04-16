using System;
using System.Collections.Generic;

namespace WeddingWebAPI.Models;

public partial class tb_Product
{
    public int ProductID { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? StockQuantity { get; set; }

    public string? ImageUrl { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public int? CategoryID { get; set; }

    public virtual tb_Category? Category { get; set; }

    public virtual ICollection<tb_Cart> tb_Carts { get; set; } = new List<tb_Cart>();

    public virtual ICollection<tb_OrderDetail> tb_OrderDetails { get; set; } = new List<tb_OrderDetail>();

    public virtual ICollection<tb_ProductReview> tb_ProductReviews { get; set; } = new List<tb_ProductReview>();
}
