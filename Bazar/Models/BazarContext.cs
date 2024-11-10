using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bazar.Models;

public partial class BazarContext : DbContext
{
    public BazarContext()
    {
    }

    public BazarContext(DbContextOptions<BazarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dimension> Dimensions { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-Q3QN8OR;Database=bazar;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dimension>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Dimensio__3213E83F334F0780");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Depth)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("depth");
            entity.Property(e => e.Height)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("height");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Width)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("width");

            entity.HasOne(d => d.Product).WithMany(p => p.Dimensions)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Dimension__produ__3C69FB99");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Images__3213E83F8B7D336E");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsThumbnail)
                .HasDefaultValue(false)
                .HasColumnName("isThumbnail");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Url)
                .HasColumnType("text")
                .HasColumnName("url");

            entity.HasOne(d => d.Product).WithMany(p => p.Images)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Images__productI__4316F928");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3213E83F7FB43D3F");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AvailabilityStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("availabilityStatus");
            entity.Property(e => e.Barcode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("barcode");
            entity.Property(e => e.Brand)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("brand");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DiscountPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discountPercentage");
            entity.Property(e => e.MinimumOrderQuantity).HasColumnName("minimumOrderQuantity");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.QrCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("qrCode");
            entity.Property(e => e.Rating)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("rating");
            entity.Property(e => e.ReturnPolicy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("returnPolicy");
            entity.Property(e => e.ShippingInformation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("shippingInformation");
            entity.Property(e => e.Sku)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sku");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("thumbnail");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.WarrantyInformation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("warrantyInformation");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("weight");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reviews__3213E83F31CADFC9");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReviewerEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("reviewerEmail");
            entity.Property(e => e.ReviewerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("reviewerName");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Reviews__product__3F466844");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sales__3214EC0786EC65C3");

            entity.Property(e => e.SaleDate).HasColumnType("datetime");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Sales__ProductId__45F365D3");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tags__3213E83FDF0ECD25");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Tag1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tag");

            entity.HasOne(d => d.Product).WithMany(p => p.Tags)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Tags__productId__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
