using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingWebAPI.Models;

public partial class tb_User
{
    public int UserID { get; set; }

    public string FullName { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    public string? NumberPhone { get; set; }

    public string? Address { get; set; }

    public string? Role { get; set; } = "User";

    public DateOnly? CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public virtual ICollection<tb_Cart> tb_Carts { get; set; } = new List<tb_Cart>();

    public virtual ICollection<tb_Order> tb_Orders { get; set; } = new List<tb_Order>();

    public virtual ICollection<tb_ProductReview> tb_ProductReviews { get; set; } = new List<tb_ProductReview>();
}
