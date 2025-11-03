using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Prn232Project.Models;

namespace Prn232Project.Data;

public partial class CloneEbayDbContext : DbContext
{
    public CloneEbayDbContext()
    {
    }

    public CloneEbayDbContext(DbContextOptions<CloneEbayDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Bid> Bids { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<Dispute> Disputes { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderTable> OrderTables { get; set; }
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ReturnRequest> ReturnRequests { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ShippingInfo> ShippingInfos { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Address__3213E83FE283DFA1");

            entity.ToTable("Address");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("fullName");
            entity.Property(e => e.IsDefault).HasColumnName("isDefault");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .HasColumnName("street");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Address__userId__3A81B327");
        });

        modelBuilder.Entity<Bid>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bid__3213E83F2651B77D");

            entity.ToTable("Bid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.BidTime)
                .HasColumnType("datetime")
                .HasColumnName("bidTime");
            entity.Property(e => e.BidderId).HasColumnName("bidderId");
            entity.Property(e => e.ProductId).HasColumnName("productId");

            entity.HasOne(d => d.Bidder).WithMany(p => p.Bids)
                .HasForeignKey(d => d.BidderId)
                .HasConstraintName("FK__Bid__bidderId__5629CD9C");

            entity.HasOne(d => d.Product).WithMany(p => p.Bids)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Bid__productId__5535A963");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3213E83F2EFB0A5B");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Coupon__3213E83F6B4E6588");

            entity.ToTable("Coupon");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.DiscountPercent)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discountPercent");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.MaxUsage).HasColumnName("maxUsage");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");

            entity.HasOne(d => d.Product).WithMany(p => p.Coupons)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Coupon__productI__60A75C0F");
        });

        modelBuilder.Entity<Dispute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Dispute__3213E83FA575F05B");

            entity.ToTable("Dispute");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.RaisedBy).HasColumnName("raisedBy");
            entity.Property(e => e.Resolution).HasColumnName("resolution");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");

            entity.HasOne(d => d.Order).WithMany(p => p.Disputes)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Dispute__orderId__693CA210");

            entity.HasOne(d => d.RaisedByNavigation).WithMany(p => p.Disputes)
                .HasForeignKey(d => d.RaisedBy)
                .HasConstraintName("FK__Dispute__raisedB__6A30C649");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feedback__3213E83FF0677904");

            entity.ToTable("Feedback");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AverageRating)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("averageRating");
            entity.Property(e => e.PositiveRate)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("positiveRate");
            entity.Property(e => e.SellerId).HasColumnName("sellerId");
            entity.Property(e => e.TotalReviews).HasColumnName("totalReviews");

            entity.HasOne(d => d.Seller).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__Feedback__seller__66603565");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventor__3213E83F5BA92A1D");

            entity.ToTable("Inventory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LastUpdated)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdated");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Inventory__produ__6383C8BA");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Message__3213E83FBFBF0CE2");

            entity.ToTable("Message");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.ReceiverId).HasColumnName("receiverId");
            entity.Property(e => e.SenderId).HasColumnName("senderId");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.Receiver).WithMany(p => p.MessageReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .HasConstraintName("FK__Message__receive__5DCAEF64");

            entity.HasOne(d => d.Sender).WithMany(p => p.MessageSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK__Message__senderI__5CD6CB2B");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3213E83F085BA5C8");

            entity.ToTable("OrderItem");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unitPrice");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__order__46E78A0C");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderItem__produ__47DBAE45");
        });

        modelBuilder.Entity<OrderTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderTab__3213E83F53068A32");

            entity.ToTable("OrderTable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("addressId");
            entity.Property(e => e.BuyerId).HasColumnName("buyerId");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("orderDate");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalPrice");

            entity.HasOne(d => d.Address).WithMany(p => p.OrderTables)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__OrderTabl__addre__440B1D61");

            entity.HasOne(d => d.Buyer).WithMany(p => p.OrderTables)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK__OrderTabl__buyer__4316F928");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3213E83F3A68E03F");

            entity.ToTable("Payment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Method)
                .HasMaxLength(50)
                .HasColumnName("method");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.PaidAt)
                .HasColumnType("datetime")
                .HasColumnName("paidAt");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Payment__orderId__4AB81AF0");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Payment__userId__4BAC3F29");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3213E83F5DB12984");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuctionEndTime)
                .HasColumnType("datetime")
                .HasColumnName("auctionEndTime");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Images).HasColumnName("images");
            entity.Property(e => e.IsAuction).HasColumnName("isAuction");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.SellerId).HasColumnName("sellerId");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Product__categor__3F466844");

            entity.HasOne(d => d.Seller).WithMany(p => p.Products)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__Product__sellerI__403A8C7D");
        });

        modelBuilder.Entity<ReturnRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ReturnRe__3213E83F5992DCFD");

            entity.ToTable("ReturnRequest");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Order).WithMany(p => p.ReturnRequests)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__ReturnReq__order__5165187F");

            entity.HasOne(d => d.User).WithMany(p => p.ReturnRequests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ReturnReq__userI__52593CB8");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Review__3213E83F89E1D570");

            entity.ToTable("Review");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReviewerId).HasColumnName("reviewerId");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Review__productI__59063A47");

            entity.HasOne(d => d.Reviewer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ReviewerId)
                .HasConstraintName("FK__Review__reviewer__59FA5E80");
        });

        modelBuilder.Entity<ShippingInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shipping__3213E83F85FA378C");

            entity.ToTable("ShippingInfo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Carrier)
                .HasMaxLength(100)
                .HasColumnName("carrier");
            entity.Property(e => e.EstimatedArrival)
                .HasColumnType("datetime")
                .HasColumnName("estimatedArrival");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(100)
                .HasColumnName("trackingNumber");

            entity.HasOne(d => d.Order).WithMany(p => p.ShippingInfos)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__ShippingI__order__4E88ABD4");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Store__3213E83F7A7A4E3D");

            entity.ToTable("Store");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BannerImageUrl).HasColumnName("bannerImageURL");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.SellerId).HasColumnName("sellerId");
            entity.Property(e => e.StoreName)
                .HasMaxLength(100)
                .HasColumnName("storeName");

            entity.HasOne(d => d.Seller).WithMany(p => p.Stores)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__Store__sellerId__6D0D32F4");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83F558D5DB7");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__AB6E6164B92F732F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvatarUrl).HasColumnName("avatarURL");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
        });
        // 🧍 Seed Users
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "seller1", Email = "seller1@example.com", Password = "AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==", Role = "seller", AvatarUrl = "https://example.com/avatars/seller1.jpg" },
            new User { Id = 2, Username = "seller2", Email = "seller2@example.com", Password = "AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==", Role = "seller", AvatarUrl = "https://example.com/avatars/seller2.jpg" },
            new User { Id = 3, Username = "seller3", Email = "seller3@example.com", Password = "AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==", Role = "seller", AvatarUrl = "https://example.com/avatars/seller3.jpg" },
            new User { Id = 4, Username = "buyer1", Email = "buyer1@example.com", Password = "AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==", Role = "buyer", AvatarUrl = "https://example.com/avatars/buyer1.jpg" },
            new User { Id = 5, Username = "buyer2", Email = "buyer2@example.com", Password = "AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==", Role = "buyer", AvatarUrl = "https://example.com/avatars/buyer2.jpg" },
            new User { Id = 6, Username = "buyer3", Email = "buyer3@example.com", Password = "AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==", Role = "buyer", AvatarUrl = "https://example.com/avatars/buyer3.jpg" },
            new User { Id = 7, Username = "buyer4", Email = "buyer4@example.com", Password = "AQAAAAIAAYagAAAAEO/sSkgVQt/6GpbA5qw++IFFBhFeA2/hYI1EdGR9ukHJfAE+eEcP/2+/zhU2dX/CQw==", Role = "buyer", AvatarUrl = "https://example.com/avatars/buyer4.jpg" }
        );

        // 🏷️ Seed Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Fashion" },
            new Category { Id = 3, Name = "Home & Garden" },
            new Category { Id = 4, Name = "Toys & Hobbies" },
            new Category { Id = 5, Name = "Automotive" },
            new Category { Id = 6, Name = "Health & Beauty" },
            new Category { Id = 7, Name = "Sports" },
            new Category { Id = 8, Name = "Books & Media" },
            new Category { Id = 9, Name = "Art & Collectibles" },
            new Category { Id = 10, Name = "Pet Supplies" }
        );

        // 📦 Seed Products
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Title = "iPhone 15 Pro Max 256GB", Description = "Brand new, unopened box. Official Apple warranty.", Price = 34990000, Images = "https://example.com/images/iphone15.jpg", CategoryId = 1, SellerId = 1, IsAuction = false },
            new Product { Id = 2, Title = "Samsung Galaxy S24 Ultra", Description = "Flagship Android phone, 12GB RAM, 512GB storage.", Price = 28990000, Images = "https://example.com/images/s24ultra.jpg", CategoryId = 1, SellerId = 1, IsAuction = false },
            new Product { Id = 3, Title = "Nike Air Force 1", Description = "Classic white sneakers, size 42.", Price = 2500000, Images = "https://example.com/images/airforce1.jpg", CategoryId = 2, SellerId = 1, IsAuction = false },
            new Product { Id = 4, Title = "Wooden Coffee Table", Description = "Solid oak coffee table, modern style.", Price = 1800000, Images = "https://example.com/images/coffeetable.jpg", CategoryId = 3, SellerId = 1, IsAuction = false },
            new Product { Id = 5, Title = "Lego Star Wars Millennium Falcon", Description = "Brand new, collector’s edition set.", Price = 5500000, Images = "https://example.com/images/lego-falcon.jpg", CategoryId = 4, SellerId = 1, IsAuction = false },
            new Product { Id = 6, Title = "Mobil 1 Engine Oil 5W-30", Description = "High-performance synthetic motor oil.", Price = 900000, Images = "https://example.com/images/mobil1.jpg", CategoryId = 5, SellerId = 1, IsAuction = false },
            new Product { Id = 7, Title = "L’Oreal Face Cream", Description = "Anti-aging moisturizer for daily use.", Price = 450000, Images = "https://example.com/images/loreal.jpg", CategoryId = 6, SellerId = 1, IsAuction = false },
            new Product { Id = 8, Title = "Adidas Football", Description = "Official size 5 match ball.", Price = 700000, Images = "https://example.com/images/adidasball.jpg", CategoryId = 7, SellerId = 1, IsAuction = false },
            new Product { Id = 9, Title = "Harry Potter Box Set", Description = "All 7 books in a hardcover collection.", Price = 950000, Images = "https://example.com/images/harrypotter.jpg", CategoryId = 8, SellerId = 1, IsAuction = false },
            new Product { Id = 10, Title = "Vintage Painting", Description = "Original 1960s oil painting, framed.", Price = 8500000, Images = "https://example.com/images/painting.jpg", CategoryId = 9, SellerId = 1, IsAuction = true, AuctionEndTime = new DateTime(2025, 11, 10, 12, 0, 0) }
        );
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
