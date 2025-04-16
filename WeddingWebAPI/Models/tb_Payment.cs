using System;
using System.Collections.Generic;

namespace WeddingWebAPI.Models;

public partial class tb_Payment
{
    public int PaymentID { get; set; }

    public int? OrderID { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public string? PaymentMethod { get; set; }

    public decimal? Amount { get; set; }

    public string? Status { get; set; }

    public virtual tb_Order? Order { get; set; }
}
