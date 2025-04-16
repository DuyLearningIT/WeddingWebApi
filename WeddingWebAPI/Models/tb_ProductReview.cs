using System;
using System.Collections.Generic;

namespace WeddingWebAPI.Models;

public partial class tb_ProductReview
{
    public int ReviewID { get; set; }

    public int? ProductID { get; set; }

    public int? UserID { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public virtual tb_Product? Product { get; set; }

    public virtual tb_User? User { get; set; }
}
