using FIt3d.DAL.Entities;
using FIt3d.DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace FIt3d.DAL.Data
{
    public class Fit3dDbContext : DbContext
    {
        public Fit3dDbContext(DbContextOptions<Fit3dDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        // Subscription DbSets
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<AIUsageLog> AIUsageLogs { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set default schema to fit3d
            modelBuilder.HasDefaultSchema("fit3d");

            // User configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // Category configuration
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // Product configuration
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.SalePrice).HasColumnType("decimal(18,2)");
                entity.HasQueryFilter(e => !e.IsDeleted);

                entity.HasOne(e => e.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ProductSize configuration
            modelBuilder.Entity<ProductSize>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Size).IsRequired().HasMaxLength(20);
                entity.HasQueryFilter(e => !e.IsDeleted);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ProductColor configuration
            modelBuilder.Entity<ProductColor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ColorName).IsRequired().HasMaxLength(50);
                entity.HasQueryFilter(e => !e.IsDeleted);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Order configuration
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OrderNumber).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.OrderNumber).IsUnique();
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.ShippingFee).HasColumnType("decimal(18,2)");
                entity.HasQueryFilter(e => !e.IsDeleted);

                entity.HasOne(e => e.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // OrderItem configuration
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)");
                entity.HasQueryFilter(e => !e.IsDeleted);

                entity.HasOne(e => e.Order)
                    .WithMany(o => o.OrderItems)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // CartItem configuration
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasQueryFilter(e => !e.IsDeleted);

                entity.HasOne(e => e.User)
                    .WithMany(u => u.CartItems)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // SubscriptionPlan configuration
            modelBuilder.Entity<SubscriptionPlan>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // Subscription configuration
            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18,2)");
                entity.HasQueryFilter(e => !e.IsDeleted);

                entity.HasOne(e => e.User)
                    .WithMany(u => u.Subscriptions)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.SubscriptionPlan)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(e => e.SubscriptionPlanId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // AIUsageLog configuration
            modelBuilder.Entity<AIUsageLog>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasQueryFilter(e => !e.IsDeleted);

                entity.HasOne(e => e.User)
                    .WithMany(u => u.AIUsageLogs)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Subscription)
                    .WithMany(s => s.AIUsageLogs)
                    .HasForeignKey(e => e.SubscriptionId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Model configuration
            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.HasQueryFilter(e => !e.IsDeleted);

                entity.HasOne(e => e.Subscription)
                    .WithMany(s => s.Models)
                    .HasForeignKey(e => e.SubscriptionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Transaction configuration
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
                entity.HasQueryFilter(e => !e.IsDeleted);

                entity.HasOne(e => e.Order)
                    .WithMany()
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // RefreshToken configuration
            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Token).IsRequired().HasMaxLength(500);
                entity.HasIndex(e => e.Token).IsUnique();
                entity.HasQueryFilter(e => !e.IsDeleted);

                entity.HasOne(e => e.User)
                    .WithMany(u => u.RefreshTokens)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Seed Data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Users
            var adminId = Guid.Parse("ef0e2aff-84ad-4a3b-8486-6131eff68548");
            var customerId1 = Guid.Parse("ef811dc4-971f-4db4-a7cf-72146baaa223");
            var customerId2 = Guid.Parse("87209cbb-f1b3-45bb-a669-6c6741f6676f");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = adminId,
                    FullName = "Admin User",
                    Email = "admin@fit3d.com",
                    PasswordHash = "AQAAAAIAAYagAAAAEJ8g1234567890abcdefghijklmnop", // Placeholder hash
                    Phone = "0901234567",
                    Address = "123 Admin Street, Ho Chi Minh City",
                    Role = UserRole.Admin,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new User
                {
                    Id = customerId1,
                    FullName = "Nguyen Van A",
                    Email = "nguyenvana@gmail.com",
                    PasswordHash = "AQAAAAIAAYagAAAAEJ8g1234567890abcdefghijklmnop",
                    Phone = "0912345678",
                    Address = "456 Customer Lane, Ha Noi",
                    Role = UserRole.Customer,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc)
                },
                new User
                {
                    Id = customerId2,
                    FullName = "Tran Thi B",
                    Email = "tranthib@gmail.com",
                    PasswordHash = "AQAAAAIAAYagAAAAEJ8g1234567890abcdefghijklmnop",
                    Phone = "0923456789",
                    Address = "789 Shopping Street, Da Nang",
                    Role = UserRole.Customer,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            // Seed Categories
            var categoryTshirt = Guid.Parse("2174b77a-b7fe-4027-90a6-7f8bbd9cc062");
            var categoryPants = Guid.Parse("7ef1156c-4412-436c-a7e5-1c0d11b7da91");
            var categoryDress = Guid.Parse("f65c980b-aca4-40d4-8179-3acbe852d4fd");
            var categoryAccessories = Guid.Parse("d94a333b-96ba-4390-b69c-f6244560b421");

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = categoryTshirt,
                    Name = "T-Shirts",
                    Description = "Comfortable and stylish t-shirts for everyday wear",
                    ImageUrl = "https://example.com/images/categories/tshirts.jpg",
                    DisplayOrder = 1,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = categoryPants,
                    Name = "Pants",
                    Description = "Quality pants and trousers for all occasions",
                    ImageUrl = "https://example.com/images/categories/pants.jpg",
                    DisplayOrder = 2,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = categoryDress,
                    Name = "Dresses",
                    Description = "Elegant dresses for women",
                    ImageUrl = "https://example.com/images/categories/dresses.jpg",
                    DisplayOrder = 3,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = categoryAccessories,
                    Name = "Accessories",
                    Description = "Fashion accessories to complete your look",
                    ImageUrl = "https://example.com/images/categories/accessories.jpg",
                    DisplayOrder = 4,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            // Seed Subscription Plans
            var stylistProMonthly = Guid.Parse("d6bbc62a-2662-4160-8b83-44c76aae92ba");
            var stylistProYearly = Guid.Parse("cffc1e89-46b3-4efa-a6d4-3fbcfe6f3f91");
            var b2bBasic = Guid.Parse("9c1b53da-63f7-4b60-9160-9edd5eaafb56");
            var b2bPro = Guid.Parse("8c00ef67-3541-499b-aaf0-7597b9465466");
            var b2bEnterprise = Guid.Parse("ef5a64aa-00fb-4b57-a946-869dcf988331");
            var basicPayPlanId = Guid.Parse("f5296a48-bd21-4341-a462-50d327d3ee72");
            var premiumPayPlanId = Guid.Parse("9be6d44f-c0bd-4821-a0f7-657eb75a29fe");

            modelBuilder.Entity<SubscriptionPlan>().HasData(
                // B2C Stylist Pro Plans
                new SubscriptionPlan
                {
                    Id = stylistProMonthly,
                    Name = "Stylist Pro Monthly",
                    Description = "Gói Stylist Pro hàng tháng - AI ?? xu?t màu s?c & phong cách, ch?nh s?a model gi?i h?n",
                    PlanType = PlanType.B2C_StylistPro,
                    Price = 99000m,
                    DurationInDays = 30,
                    MaxModels = 5,
                    MaxEditsPerModel = 10,
                    MaxAIRequestsPerMonth = 50,
                    HasAIFeature = true,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new SubscriptionPlan
                {
                    Id = stylistProYearly,
                    Name = "Stylist Pro Yearly",
                    Description = "Gói Stylist Pro n?m - Ti?t ki?m 20%, AI ?? xu?t không gi?i h?n, ch?nh s?a model nhi?u h?n",
                    PlanType = PlanType.B2C_StylistPro,
                    Price = 950000m,
                    DurationInDays = 365,
                    MaxModels = 20,
                    MaxEditsPerModel = 30,
                    MaxAIRequestsPerMonth = 200,
                    HasAIFeature = true,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                // B2B Shop Plans
                new SubscriptionPlan
                {
                    Id = b2bBasic,
                    Name = "B2B Basic",
                    Description = "Gói c? b?n cho shop - 50 model ph?i ??, 10 l?n ch?nh s?a/model",
                    PlanType = PlanType.B2B_Shop,
                    Price = 499000m,
                    DurationInDays = 30,
                    MaxModels = 50,
                    MaxEditsPerModel = 10,
                    MaxAIRequestsPerMonth = 0,
                    HasAIFeature = false,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new SubscriptionPlan
                {
                    Id = b2bPro,
                    Name = "B2B Pro",
                    Description = "Gói Pro cho shop - 200 model ph?i ??, 20 l?n ch?nh s?a/model, h? tr? ?u tiên",
                    PlanType = PlanType.B2B_Shop,
                    Price = 1490000m,
                    DurationInDays = 30,
                    MaxModels = 200,
                    MaxEditsPerModel = 20,
                    MaxAIRequestsPerMonth = 0,
                    HasAIFeature = false,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new SubscriptionPlan
                {
                    Id = b2bEnterprise,
                    Name = "B2B Enterprise",
                    Description = "Gói Enterprise cho shop - 1000 model ph?i ??, 50 l?n ch?nh s?a/model, API access",
                    PlanType = PlanType.B2B_Shop,
                    Price = 4990000m,
                    DurationInDays = 30,
                    MaxModels = 1000,
                    MaxEditsPerModel = 50,
                    MaxAIRequestsPerMonth = 0,
                    HasAIFeature = false,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new SubscriptionPlan
                {
                    Id = basicPayPlanId,
                    Name = "Gói C? B?n",
                    Description = "Gói c? b?n 100.000 VND/tháng - Tr?i nghi?m tính n?ng AI c? b?n",
                    PlanType = PlanType.B2C_StylistPro,
                    Price = 100000m,
                    DurationInDays = 30,
                    MaxModels = 3,
                    MaxEditsPerModel = 5,
                    MaxAIRequestsPerMonth = 20,
                    HasAIFeature = true,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new SubscriptionPlan
                {
                    Id = premiumPayPlanId,
                    Name = "Gói Nâng Cao",
                    Description = "Gói nâng cao 200.000 VND/tháng - Tr?i nghi?m ??y ?? tính n?ng AI",
                    PlanType = PlanType.B2C_StylistPro,
                    Price = 200000m,
                    DurationInDays = 30,
                    MaxModels = 10,
                    MaxEditsPerModel = 20,
                    MaxAIRequestsPerMonth = 100,
                    HasAIFeature = true,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            // Seed Products
            var product1 = Guid.Parse("cb2e4c53-0754-487d-9bc2-8a8e5a5a8ff7");
            var product2 = Guid.Parse("d26859fa-798d-4341-b8c7-a2760b4b7522");
            var product3 = Guid.Parse("3319290d-7bc6-4f66-955e-0bff16902e4f");
            var product4 = Guid.Parse("a2561418-c8a0-4451-9caf-2cc58c625d1e");
            var product5 = Guid.Parse("78575687-a6be-47fe-9fd9-7fa0dec32b66");

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = product1,
                    Name = "Classic Cotton T-Shirt",
                    Description = "A timeless classic cotton t-shirt with a comfortable fit. Perfect for casual wear.",
                    Price = 299000m,
                    SalePrice = 249000m,
                    SKU = "TS-001",
                    Brand = "Fit3D",
                    ImageUrl = "https://example.com/images/products/tshirt-classic.jpg",
                    StockQuantity = 100,
                    IsActive = true,
                    IsFeatured = true,
                    CategoryId = categoryTshirt,
                    CreatedAt = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc)
                },
                new Product
                {
                    Id = product2,
                    Name = "Premium Polo Shirt",
                    Description = "Elegant polo shirt made from premium cotton blend. Great for smart casual occasions.",
                    Price = 450000m,
                    SalePrice = null,
                    SKU = "TS-002",
                    Brand = "Fit3D",
                    ImageUrl = "https://example.com/images/products/polo-premium.jpg",
                    StockQuantity = 75,
                    IsActive = true,
                    IsFeatured = true,
                    CategoryId = categoryTshirt,
                    CreatedAt = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc)
                },
                new Product
                {
                    Id = product3,
                    Name = "Slim Fit Jeans",
                    Description = "Modern slim fit jeans with stretch for ultimate comfort. Available in multiple washes.",
                    Price = 650000m,
                    SalePrice = 550000m,
                    SKU = "PT-001",
                    Brand = "Fit3D Denim",
                    ImageUrl = "https://example.com/images/products/jeans-slim.jpg",
                    StockQuantity = 50,
                    IsActive = true,
                    IsFeatured = false,
                    CategoryId = categoryPants,
                    CreatedAt = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc)
                },
                new Product
                {
                    Id = product4,
                    Name = "Floral Summer Dress",
                    Description = "Beautiful floral print summer dress. Light and breezy fabric perfect for warm days.",
                    Price = 780000m,
                    SalePrice = 680000m,
                    SKU = "DR-001",
                    Brand = "Fit3D Ladies",
                    ImageUrl = "https://example.com/images/products/dress-floral.jpg",
                    StockQuantity = 30,
                    IsActive = true,
                    IsFeatured = true,
                    CategoryId = categoryDress,
                    CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Product
                {
                    Id = product5,
                    Name = "Leather Belt",
                    Description = "Genuine leather belt with classic buckle. Perfect accessory for any outfit.",
                    Price = 350000m,
                    SalePrice = null,
                    SKU = "AC-001",
                    Brand = "Fit3D Accessories",
                    ImageUrl = "https://example.com/images/products/belt-leather.jpg",
                    StockQuantity = 60,
                    IsActive = true,
                    IsFeatured = false,
                    CategoryId = categoryAccessories,
                    CreatedAt = new DateTime(2024, 2, 5, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            // Seed Product Sizes
            modelBuilder.Entity<ProductSize>().HasData(
                // T-Shirt sizes
                new ProductSize { Id = Guid.Parse("6b476d78-3bb1-436c-afad-9521b8e48f50"), ProductId = product1, Size = "S", StockQuantity = 25, CreatedAt = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("e626bf6b-d999-459b-9cff-82271cad1b48"), ProductId = product1, Size = "M", StockQuantity = 30, CreatedAt = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("7072a38f-5eda-4d27-8df3-d26aff252d35"), ProductId = product1, Size = "L", StockQuantity = 25, CreatedAt = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("3a4efbb6-f308-4cae-ba63-3beb600ba00c"), ProductId = product1, Size = "XL", StockQuantity = 20, CreatedAt = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                // Polo shirt sizes
                new ProductSize { Id = Guid.Parse("4bc01d6a-9083-4c4e-bf05-b46fd6f3d890"), ProductId = product2, Size = "S", StockQuantity = 20, CreatedAt = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("d5bcdd99-b3a6-4c33-9886-ca5e643bf0a1"), ProductId = product2, Size = "M", StockQuantity = 25, CreatedAt = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("873dbef2-761a-4010-8e71-1637b791603d"), ProductId = product2, Size = "L", StockQuantity = 20, CreatedAt = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                // Jeans sizes
                new ProductSize { Id = Guid.Parse("4dbd716c-8099-47ba-9062-97638f61d4e6"), ProductId = product3, Size = "28", StockQuantity = 10, CreatedAt = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("8ee03cf8-12ae-4040-933b-8d4fa1893131"), ProductId = product3, Size = "30", StockQuantity = 15, CreatedAt = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("5348d1b0-aa23-45d9-980e-bab1eba81b3b"), ProductId = product3, Size = "32", StockQuantity = 15, CreatedAt = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("78f7af9d-961b-4ba9-8b20-20ae118b16c6"), ProductId = product3, Size = "34", StockQuantity = 10, CreatedAt = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc) },
                // Dress sizes
                new ProductSize { Id = Guid.Parse("666c92f7-b4f3-40c0-a8ee-bf49ecf1deef"), ProductId = product4, Size = "S", StockQuantity = 10, CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("5b84b9dc-7523-439d-afd6-d7bdfbde772c"), ProductId = product4, Size = "M", StockQuantity = 12, CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("2f9c198c-f08e-4227-9700-4ec8b06f73ea"), ProductId = product4, Size = "L", StockQuantity = 8, CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc) }
            );

            // Seed Product Colors
            modelBuilder.Entity<ProductColor>().HasData(
                // T-Shirt colors
                new ProductColor { Id = Guid.Parse("a289b4b2-2cfa-4aea-969a-b53baa3a6ede"), ProductId = product1, ColorName = "White", ColorCode = "#FFFFFF", StockQuantity = 35, CreatedAt = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                new ProductColor { Id = Guid.Parse("2fa71da7-5c2f-4f7e-8e92-207d3aa2df92"), ProductId = product1, ColorName = "Black", ColorCode = "#000000", StockQuantity = 35, CreatedAt = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                new ProductColor { Id = Guid.Parse("872267f3-eeb6-46ae-82cd-8077aeadabbf"), ProductId = product1, ColorName = "Navy Blue", ColorCode = "#000080", StockQuantity = 30, CreatedAt = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                // Polo colors
                new ProductColor { Id = Guid.Parse("509b2af9-8024-4dbf-806a-b5880a836088"), ProductId = product2, ColorName = "White", ColorCode = "#FFFFFF", StockQuantity = 25, CreatedAt = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                new ProductColor { Id = Guid.Parse("29c61d39-039e-485c-99ff-265a024f82c8"), ProductId = product2, ColorName = "Light Blue", ColorCode = "#ADD8E6", StockQuantity = 25, CreatedAt = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                new ProductColor { Id = Guid.Parse("8ef84190-3522-48da-95af-96735fab3301"), ProductId = product2, ColorName = "Pink", ColorCode = "#FFC0CB", StockQuantity = 25, CreatedAt = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                // Jeans colors
                new ProductColor { Id = Guid.Parse("ac4541e7-ae1b-42c9-9912-29d77f0a0453"), ProductId = product3, ColorName = "Blue Wash", ColorCode = "#4169E1", StockQuantity = 25, CreatedAt = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc) },
                new ProductColor { Id = Guid.Parse("99955166-1bc8-413c-bb33-c1a16a2269e6"), ProductId = product3, ColorName = "Dark Wash", ColorCode = "#191970", StockQuantity = 25, CreatedAt = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc) },
                // Dress colors
                new ProductColor { Id = Guid.Parse("f0ed1a32-6a07-486c-ae4c-3648dd7bf4d4"), ProductId = product4, ColorName = "Floral Pink", ColorCode = "#FFB6C1", StockQuantity = 15, CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
                new ProductColor { Id = Guid.Parse("ee72276f-52dd-4400-9402-2b3e2d9f2eb7"), ProductId = product4, ColorName = "Floral Blue", ColorCode = "#87CEEB", StockQuantity = 15, CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
                // Belt colors
                new ProductColor { Id = Guid.Parse("6493149e-6c21-4f3b-9ae2-40ac2698d7a4"), ProductId = product5, ColorName = "Brown", ColorCode = "#8B4513", StockQuantity = 30, CreatedAt = new DateTime(2024, 2, 5, 0, 0, 0, DateTimeKind.Utc) },
                new ProductColor { Id = Guid.Parse("c29c562c-6432-4add-a1fc-fbbcca40258d"), ProductId = product5, ColorName = "Black", ColorCode = "#000000", StockQuantity = 30, CreatedAt = new DateTime(2024, 2, 5, 0, 0, 0, DateTimeKind.Utc) }
            );

            // Seed Orders
            var order1 = Guid.Parse("abc47c23-b9b5-495f-ad2d-67d0b8b598a4");
            var order2 = Guid.Parse("861f041d-6422-4734-a615-6ec5a95683ac");

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = order1,
                    OrderNumber = "ORD-2024-0001",
                    TotalAmount = 798000m,
                    DiscountAmount = 50000m,
                    ShippingFee = 30000m,
                    Status = OrderStatus.Delivered,
                    PaymentStatus = PaymentStatus.Paid,
                    PaymentMethod = "COD",
                    ShippingAddress = "456 Customer Lane, Ha Noi",
                    ReceiverName = "Nguyen Van A",
                    ReceiverPhone = "0912345678",
                    Note = "Please call before delivery",
                    UserId = customerId1,
                    ShippedAt = new DateTime(2024, 2, 3, 0, 0, 0, DateTimeKind.Utc),
                    DeliveredAt = new DateTime(2024, 2, 5, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Order
                {
                    Id = order2,
                    OrderNumber = "ORD-2024-0002",
                    TotalAmount = 1130000m,
                    DiscountAmount = null,
                    ShippingFee = 0m,
                    Status = OrderStatus.Processing,
                    PaymentStatus = PaymentStatus.Paid,
                    PaymentMethod = "VNPay",
                    ShippingAddress = "789 Shopping Street, Da Nang",
                    ReceiverName = "Tran Thi B",
                    ReceiverPhone = "0923456789",
                    Note = null,
                    UserId = customerId2,
                    ShippedAt = null,
                    DeliveredAt = null,
                    CreatedAt = new DateTime(2024, 2, 10, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            // Seed Order Items
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    Id = Guid.Parse("f43272b8-57f2-4c6e-8a4a-068a33beffa2"),
                    OrderId = order1,
                    ProductId = product1,
                    Quantity = 2,
                    UnitPrice = 249000m,
                    TotalPrice = 498000m,
                    Size = "M",
                    Color = "White",
                    CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new OrderItem
                {
                    Id = Guid.Parse("1fb2f6fe-9474-47d1-a0b7-fc70834e3a70"),
                    OrderId = order1,
                    ProductId = product5,
                    Quantity = 1,
                    UnitPrice = 350000m,
                    TotalPrice = 350000m,
                    Size = null,
                    Color = "Brown",
                    CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new OrderItem
                {
                    Id = Guid.Parse("d423bc83-9867-4990-af10-2787d2eec805"),
                    OrderId = order2,
                    ProductId = product3,
                    Quantity = 1,
                    UnitPrice = 550000m,
                    TotalPrice = 550000m,
                    Size = "30",
                    Color = "Blue Wash",
                    CreatedAt = new DateTime(2024, 2, 10, 0, 0, 0, DateTimeKind.Utc)
                },
                new OrderItem
                {
                    Id = Guid.Parse("e1456c51-45da-45df-a394-80d3ff068395"),
                    OrderId = order2,
                    ProductId = product4,
                    Quantity = 1,
                    UnitPrice = 680000m,
                    TotalPrice = 680000m,
                    Size = "M",
                    Color = "Floral Pink",
                    CreatedAt = new DateTime(2024, 2, 10, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            // Seed Cart Items
            modelBuilder.Entity<CartItem>().HasData(
                new CartItem
                {
                    Id = Guid.Parse("397325b0-8306-47fb-876a-2167c7559b7a"),
                    UserId = customerId1,
                    ProductId = product2,
                    Quantity = 1,
                    Size = "L",
                    Color = "Light Blue",
                    CreatedAt = new DateTime(2024, 2, 15, 0, 0, 0, DateTimeKind.Utc)
                },
                new CartItem
                {
                    Id = Guid.Parse("641f6db7-0163-4477-a8f5-4eb0064d1a68"),
                    UserId = customerId2,
                    ProductId = product1,
                    Quantity = 3,
                    Size = "S",
                    Color = "Black",
                    CreatedAt = new DateTime(2024, 2, 16, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
