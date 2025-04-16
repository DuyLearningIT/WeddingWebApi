using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WeddingWebAPI.Models;

namespace WeddingWebAPI.Data;

public partial class dbContext : DbContext
{
    public dbContext()
    {
    }

    public dbContext(DbContextOptions<dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<tb_Cart> tb_Carts { get; set; }

    public virtual DbSet<tb_Category> tb_Categories { get; set; }

    public virtual DbSet<tb_Order> tb_Orders { get; set; }

    public virtual DbSet<tb_OrderDetail> tb_OrderDetails { get; set; }

    public virtual DbSet<tb_Payment> tb_Payments { get; set; }

    public virtual DbSet<tb_Product> tb_Products { get; set; }

    public virtual DbSet<tb_ProductReview> tb_ProductReviews { get; set; }

    public virtual DbSet<tb_User> tb_Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=NQD-DESKTOP\\MSSQLSERVER01;Database=E_WeddingDress;User Id=5d-tech;Password=x1@;TrustServerCertificate=True\n");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tb_Cart>(entity =>
        {
            entity.HasKey(e => e.CartID);

            entity.ToTable("tb_Cart");

            entity.HasOne(d => d.Product).WithMany(p => p.tb_Carts)
                .HasForeignKey(d => d.ProductID)
                .HasConstraintName("FK_tb_Cart_tb_Products");

            entity.HasOne(d => d.User).WithMany(p => p.tb_Carts)
                .HasForeignKey(d => d.UserID)
                .HasConstraintName("FK_tb_Cart_tb_Users");
        });

        modelBuilder.Entity<tb_Category>(entity =>
        {
            entity.HasKey(e => e.CategoryID);

            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<tb_Order>(entity =>
        {
            entity.HasKey(e => e.OrderID);

            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.User).WithMany(p => p.tb_Orders)
                .HasForeignKey(d => d.UserID)
                .HasConstraintName("FK_tb_Orders_tb_Users");
        });

        modelBuilder.Entity<tb_OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailID);

            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.tb_OrderDetails)
                .HasForeignKey(d => d.OrderID)
                .HasConstraintName("FK_tb_OrderDetails_tb_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.tb_OrderDetails)
                .HasForeignKey(d => d.ProductID)
                .HasConstraintName("FK_tb_OrderDetails_tb_Products");
        });

        modelBuilder.Entity<tb_Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentID);

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Order).WithMany(p => p.tb_Payments)
                .HasForeignKey(d => d.OrderID)
                .HasConstraintName("FK_tb_Payments_tb_Orders");
        });

        modelBuilder.Entity<tb_Product>(entity =>
        {
            entity.HasKey(e => e.ProductID);

            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.tb_Products)
                .HasForeignKey(d => d.CategoryID)
                .HasConstraintName("FK_tb_Products_tb_Categories");
        });

        modelBuilder.Entity<tb_ProductReview>(entity =>
        {
            entity.HasKey(e => e.ReviewID);

            entity.HasOne(d => d.Product).WithMany(p => p.tb_ProductReviews)
                .HasForeignKey(d => d.ProductID)
                .HasConstraintName("FK_tb_ProductReviews_tb_Products");

            entity.HasOne(d => d.User).WithMany(p => p.tb_ProductReviews)
                .HasForeignKey(d => d.UserID)
                .HasConstraintName("FK_tb_ProductReviews_tb_Users");
        });

        modelBuilder.Entity<tb_User>(entity =>
        {
            entity.HasKey(e => e.UserID);

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.NumberPhone)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(256)
                .IsFixedLength();
            entity.Property(e => e.Role).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
