using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FIt3d.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedDataRandomGuidsAndSubscriptionPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("ca111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("ca222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("01111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("02222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("03333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("04444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("11111111-2222-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-2222-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("44444444-2222-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("55555555-2222-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("66666666-2222-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("e1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("e2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("e3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("f1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("f2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("f3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("b1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("c4444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("d1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("d2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("d3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-0001-0001-0001-cccccccccccc"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-0002-0002-0002-dddddddddddd"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: new Guid("ffffffff-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: new Guid("ffffffff-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: new Guid("ffffffff-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("aaaa1111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("bbbb2222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-aaaa-1111-aaaa-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-aaaa-2222-aaaa-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-bbbb-3333-bbbb-333333333333"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-cccc-4444-cccc-444444444444"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("55555555-dddd-5555-dddd-555555555555"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "DisplayOrder", "ImageUrl", "IsActive", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2174b77a-b7fe-4027-90a6-7f8bbd9cc062"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Comfortable and stylish t-shirts for everyday wear", 1, "https://example.com/images/categories/tshirts.jpg", true, false, "T-Shirts", null },
                    { new Guid("7ef1156c-4412-436c-a7e5-1c0d11b7da91"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Quality pants and trousers for all occasions", 2, "https://example.com/images/categories/pants.jpg", true, false, "Pants", null },
                    { new Guid("d94a333b-96ba-4390-b69c-f6244560b421"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Fashion accessories to complete your look", 4, "https://example.com/images/categories/accessories.jpg", true, false, "Accessories", null },
                    { new Guid("f65c980b-aca4-40d4-8179-3acbe852d4fd"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Elegant dresses for women", 3, "https://example.com/images/categories/dresses.jpg", true, false, "Dresses", null }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                columns: new[] { "Id", "CreatedAt", "Description", "DurationInDays", "HasAIFeature", "IsActive", "IsDeleted", "MaxAIRequestsPerMonth", "MaxEditsPerModel", "MaxModels", "Name", "PlanType", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8c00ef67-3541-499b-aaf0-7597b9465466"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói Pro cho shop - 200 model ph?i ??, 20 l?n ch?nh s?a/model, h? tr? ?u tiên", 30, false, true, false, 0, 20, 200, "B2B Pro", 1, 1490000m, null },
                    { new Guid("9be6d44f-c0bd-4821-a0f7-657eb75a29fe"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói nâng cao 200.000 VND/tháng - Tr?i nghi?m ??y ?? tính n?ng AI", 30, true, true, false, 100, 20, 10, "Gói Nâng Cao", 0, 200000m, null },
                    { new Guid("9c1b53da-63f7-4b60-9160-9edd5eaafb56"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói c? b?n cho shop - 50 model ph?i ??, 10 l?n ch?nh s?a/model", 30, false, true, false, 0, 10, 50, "B2B Basic", 1, 499000m, null },
                    { new Guid("cffc1e89-46b3-4efa-a6d4-3fbcfe6f3f91"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói Stylist Pro n?m - Ti?t ki?m 20%, AI ?? xu?t không gi?i h?n, ch?nh s?a model nhi?u h?n", 365, true, true, false, 200, 30, 20, "Stylist Pro Yearly", 0, 950000m, null },
                    { new Guid("d6bbc62a-2662-4160-8b83-44c76aae92ba"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói Stylist Pro hàng tháng - AI ?? xu?t màu s?c & phong cách, ch?nh s?a model gi?i h?n", 30, true, true, false, 50, 10, 5, "Stylist Pro Monthly", 0, 99000m, null },
                    { new Guid("ef5a64aa-00fb-4b57-a946-869dcf988331"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói Enterprise cho shop - 1000 model ph?i ??, 50 l?n ch?nh s?a/model, API access", 30, false, true, false, 0, 50, 1000, "B2B Enterprise", 1, 4990000m, null },
                    { new Guid("f5296a48-bd21-4341-a462-50d327d3ee72"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói c? b?n 100.000 VND/tháng - Tr?i nghi?m tính n?ng AI c? b?n", 30, true, true, false, 20, 5, 3, "Gói C? B?n", 0, 100000m, null }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "FullName", "IsActive", "IsDeleted", "IsVerified", "LogoUrl", "PasswordHash", "Phone", "Role", "ShopDescription", "ShopName", "TaxCode", "UpdatedAt", "WebsiteUrl" },
                values: new object[,]
                {
                    { new Guid("87209cbb-f1b3-45bb-a669-6c6741f6676f"), "789 Shopping Street, Da Nang", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tranthib@gmail.com", "Tran Thi B", true, false, false, null, "AQAAAAIAAYagAAAAEJ8g1234567890abcdefghijklmnop", "0923456789", 0, null, null, null, null, null },
                    { new Guid("ef0e2aff-84ad-4a3b-8486-6131eff68548"), "123 Admin Street, Ho Chi Minh City", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@fit3d.com", "Admin User", true, false, false, null, "AQAAAAIAAYagAAAAEJ8g1234567890abcdefghijklmnop", "0901234567", 1, null, null, null, null, null },
                    { new Guid("ef811dc4-971f-4db4-a7cf-72146baaa223"), "456 Customer Lane, Ha Noi", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "nguyenvana@gmail.com", "Nguyen Van A", true, false, false, null, "AQAAAAIAAYagAAAAEJ8g1234567890abcdefghijklmnop", "0912345678", 0, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "DeliveredAt", "DiscountAmount", "IsDeleted", "Note", "OrderNumber", "PaymentMethod", "PaymentStatus", "ReceiverName", "ReceiverPhone", "ShippedAt", "ShippingAddress", "ShippingFee", "Status", "TotalAmount", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("861f041d-6422-4734-a615-6ec5a95683ac"), new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "ORD-2024-0002", "VNPay", 1, "Tran Thi B", "0923456789", null, "789 Shopping Street, Da Nang", 0m, 2, 1130000m, null, new Guid("87209cbb-f1b3-45bb-a669-6c6741f6676f") },
                    { new Guid("abc47c23-b9b5-495f-ad2d-67d0b8b598a4"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), 50000m, false, "Please call before delivery", "ORD-2024-0001", "COD", 1, "Nguyen Van A", "0912345678", new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), "456 Customer Lane, Ha Noi", 30000m, 4, 798000m, null, new Guid("ef811dc4-971f-4db4-a7cf-72146baaa223") }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedAt", "Description", "ImageUrl", "IsActive", "IsDeleted", "IsFeatured", "ModelFilePath", "Name", "PreviewModelPath", "Price", "SKU", "SalePrice", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3319290d-7bc6-4f66-955e-0bff16902e4f"), "Fit3D Denim", new Guid("7ef1156c-4412-436c-a7e5-1c0d11b7da91"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Modern slim fit jeans with stretch for ultimate comfort. Available in multiple washes.", "https://example.com/images/products/jeans-slim.jpg", true, false, false, null, "Slim Fit Jeans", null, 650000m, "PT-001", 550000m, 50, null },
                    { new Guid("78575687-a6be-47fe-9fd9-7fa0dec32b66"), "Fit3D Accessories", new Guid("d94a333b-96ba-4390-b69c-f6244560b421"), new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Genuine leather belt with classic buckle. Perfect accessory for any outfit.", "https://example.com/images/products/belt-leather.jpg", true, false, false, null, "Leather Belt", null, 350000m, "AC-001", null, 60, null },
                    { new Guid("a2561418-c8a0-4451-9caf-2cc58c625d1e"), "Fit3D Ladies", new Guid("f65c980b-aca4-40d4-8179-3acbe852d4fd"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Beautiful floral print summer dress. Light and breezy fabric perfect for warm days.", "https://example.com/images/products/dress-floral.jpg", true, false, true, null, "Floral Summer Dress", null, 780000m, "DR-001", 680000m, 30, null },
                    { new Guid("cb2e4c53-0754-487d-9bc2-8a8e5a5a8ff7"), "Fit3D", new Guid("2174b77a-b7fe-4027-90a6-7f8bbd9cc062"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "A timeless classic cotton t-shirt with a comfortable fit. Perfect for casual wear.", "https://example.com/images/products/tshirt-classic.jpg", true, false, true, null, "Classic Cotton T-Shirt", null, 299000m, "TS-001", 249000m, 100, null },
                    { new Guid("d26859fa-798d-4341-b8c7-a2760b4b7522"), "Fit3D", new Guid("2174b77a-b7fe-4027-90a6-7f8bbd9cc062"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Elegant polo shirt made from premium cotton blend. Great for smart casual occasions.", "https://example.com/images/products/polo-premium.jpg", true, false, true, null, "Premium Polo Shirt", null, 450000m, "TS-002", null, 75, null }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "CartItems",
                columns: new[] { "Id", "Color", "CreatedAt", "IsDeleted", "ProductId", "Quantity", "Size", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("397325b0-8306-47fb-876a-2167c7559b7a"), "Light Blue", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("d26859fa-798d-4341-b8c7-a2760b4b7522"), 1, "L", null, new Guid("ef811dc4-971f-4db4-a7cf-72146baaa223") },
                    { new Guid("641f6db7-0163-4477-a8f5-4eb0064d1a68"), "Black", new DateTime(2024, 2, 16, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("cb2e4c53-0754-487d-9bc2-8a8e5a5a8ff7"), 3, "S", null, new Guid("87209cbb-f1b3-45bb-a669-6c6741f6676f") }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "OrderItems",
                columns: new[] { "Id", "Color", "CreatedAt", "IsDeleted", "OrderId", "ProductId", "Quantity", "Size", "TotalPrice", "UnitPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1fb2f6fe-9474-47d1-a0b7-fc70834e3a70"), "Brown", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("abc47c23-b9b5-495f-ad2d-67d0b8b598a4"), new Guid("78575687-a6be-47fe-9fd9-7fa0dec32b66"), 1, null, 350000m, 350000m, null },
                    { new Guid("d423bc83-9867-4990-af10-2787d2eec805"), "Blue Wash", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("861f041d-6422-4734-a615-6ec5a95683ac"), new Guid("3319290d-7bc6-4f66-955e-0bff16902e4f"), 1, "30", 550000m, 550000m, null },
                    { new Guid("e1456c51-45da-45df-a394-80d3ff068395"), "Floral Pink", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("861f041d-6422-4734-a615-6ec5a95683ac"), new Guid("a2561418-c8a0-4451-9caf-2cc58c625d1e"), 1, "M", 680000m, 680000m, null },
                    { new Guid("f43272b8-57f2-4c6e-8a4a-068a33beffa2"), "White", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("abc47c23-b9b5-495f-ad2d-67d0b8b598a4"), new Guid("cb2e4c53-0754-487d-9bc2-8a8e5a5a8ff7"), 2, "M", 498000m, 249000m, null }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "ProductColors",
                columns: new[] { "Id", "ColorCode", "ColorName", "CreatedAt", "ImageUrl", "IsDeleted", "ProductId", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("29c61d39-039e-485c-99ff-265a024f82c8"), "#ADD8E6", "Light Blue", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("d26859fa-798d-4341-b8c7-a2760b4b7522"), 25, null },
                    { new Guid("2fa71da7-5c2f-4f7e-8e92-207d3aa2df92"), "#000000", "Black", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("cb2e4c53-0754-487d-9bc2-8a8e5a5a8ff7"), 35, null },
                    { new Guid("509b2af9-8024-4dbf-806a-b5880a836088"), "#FFFFFF", "White", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("d26859fa-798d-4341-b8c7-a2760b4b7522"), 25, null },
                    { new Guid("6493149e-6c21-4f3b-9ae2-40ac2698d7a4"), "#8B4513", "Brown", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("78575687-a6be-47fe-9fd9-7fa0dec32b66"), 30, null },
                    { new Guid("872267f3-eeb6-46ae-82cd-8077aeadabbf"), "#000080", "Navy Blue", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("cb2e4c53-0754-487d-9bc2-8a8e5a5a8ff7"), 30, null },
                    { new Guid("8ef84190-3522-48da-95af-96735fab3301"), "#FFC0CB", "Pink", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("d26859fa-798d-4341-b8c7-a2760b4b7522"), 25, null },
                    { new Guid("99955166-1bc8-413c-bb33-c1a16a2269e6"), "#191970", "Dark Wash", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("3319290d-7bc6-4f66-955e-0bff16902e4f"), 25, null },
                    { new Guid("a289b4b2-2cfa-4aea-969a-b53baa3a6ede"), "#FFFFFF", "White", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("cb2e4c53-0754-487d-9bc2-8a8e5a5a8ff7"), 35, null },
                    { new Guid("ac4541e7-ae1b-42c9-9912-29d77f0a0453"), "#4169E1", "Blue Wash", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("3319290d-7bc6-4f66-955e-0bff16902e4f"), 25, null },
                    { new Guid("c29c562c-6432-4add-a1fc-fbbcca40258d"), "#000000", "Black", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("78575687-a6be-47fe-9fd9-7fa0dec32b66"), 30, null },
                    { new Guid("ee72276f-52dd-4400-9402-2b3e2d9f2eb7"), "#87CEEB", "Floral Blue", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("a2561418-c8a0-4451-9caf-2cc58c625d1e"), 15, null },
                    { new Guid("f0ed1a32-6a07-486c-ae4c-3648dd7bf4d4"), "#FFB6C1", "Floral Pink", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("a2561418-c8a0-4451-9caf-2cc58c625d1e"), 15, null }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "ProductSizes",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "ProductId", "Size", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2f9c198c-f08e-4227-9700-4ec8b06f73ea"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("a2561418-c8a0-4451-9caf-2cc58c625d1e"), "L", 8, null },
                    { new Guid("3a4efbb6-f308-4cae-ba63-3beb600ba00c"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("cb2e4c53-0754-487d-9bc2-8a8e5a5a8ff7"), "XL", 20, null },
                    { new Guid("4bc01d6a-9083-4c4e-bf05-b46fd6f3d890"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("d26859fa-798d-4341-b8c7-a2760b4b7522"), "S", 20, null },
                    { new Guid("4dbd716c-8099-47ba-9062-97638f61d4e6"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("3319290d-7bc6-4f66-955e-0bff16902e4f"), "28", 10, null },
                    { new Guid("5348d1b0-aa23-45d9-980e-bab1eba81b3b"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("3319290d-7bc6-4f66-955e-0bff16902e4f"), "32", 15, null },
                    { new Guid("5b84b9dc-7523-439d-afd6-d7bdfbde772c"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("a2561418-c8a0-4451-9caf-2cc58c625d1e"), "M", 12, null },
                    { new Guid("666c92f7-b4f3-40c0-a8ee-bf49ecf1deef"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("a2561418-c8a0-4451-9caf-2cc58c625d1e"), "S", 10, null },
                    { new Guid("6b476d78-3bb1-436c-afad-9521b8e48f50"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("cb2e4c53-0754-487d-9bc2-8a8e5a5a8ff7"), "S", 25, null },
                    { new Guid("7072a38f-5eda-4d27-8df3-d26aff252d35"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("cb2e4c53-0754-487d-9bc2-8a8e5a5a8ff7"), "L", 25, null },
                    { new Guid("78f7af9d-961b-4ba9-8b20-20ae118b16c6"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("3319290d-7bc6-4f66-955e-0bff16902e4f"), "34", 10, null },
                    { new Guid("873dbef2-761a-4010-8e71-1637b791603d"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("d26859fa-798d-4341-b8c7-a2760b4b7522"), "L", 20, null },
                    { new Guid("8ee03cf8-12ae-4040-933b-8d4fa1893131"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("3319290d-7bc6-4f66-955e-0bff16902e4f"), "30", 15, null },
                    { new Guid("d5bcdd99-b3a6-4c33-9886-ca5e643bf0a1"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("d26859fa-798d-4341-b8c7-a2760b4b7522"), "M", 25, null },
                    { new Guid("e626bf6b-d999-459b-9cff-82271cad1b48"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("cb2e4c53-0754-487d-9bc2-8a8e5a5a8ff7"), "M", 30, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("397325b0-8306-47fb-876a-2167c7559b7a"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("641f6db7-0163-4477-a8f5-4eb0064d1a68"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("1fb2f6fe-9474-47d1-a0b7-fc70834e3a70"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("d423bc83-9867-4990-af10-2787d2eec805"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("e1456c51-45da-45df-a394-80d3ff068395"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("f43272b8-57f2-4c6e-8a4a-068a33beffa2"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("29c61d39-039e-485c-99ff-265a024f82c8"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("2fa71da7-5c2f-4f7e-8e92-207d3aa2df92"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("509b2af9-8024-4dbf-806a-b5880a836088"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("6493149e-6c21-4f3b-9ae2-40ac2698d7a4"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("872267f3-eeb6-46ae-82cd-8077aeadabbf"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("8ef84190-3522-48da-95af-96735fab3301"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("99955166-1bc8-413c-bb33-c1a16a2269e6"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("a289b4b2-2cfa-4aea-969a-b53baa3a6ede"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("ac4541e7-ae1b-42c9-9912-29d77f0a0453"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("c29c562c-6432-4add-a1fc-fbbcca40258d"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("ee72276f-52dd-4400-9402-2b3e2d9f2eb7"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("f0ed1a32-6a07-486c-ae4c-3648dd7bf4d4"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("2f9c198c-f08e-4227-9700-4ec8b06f73ea"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("3a4efbb6-f308-4cae-ba63-3beb600ba00c"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("4bc01d6a-9083-4c4e-bf05-b46fd6f3d890"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("4dbd716c-8099-47ba-9062-97638f61d4e6"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("5348d1b0-aa23-45d9-980e-bab1eba81b3b"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("5b84b9dc-7523-439d-afd6-d7bdfbde772c"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("666c92f7-b4f3-40c0-a8ee-bf49ecf1deef"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("6b476d78-3bb1-436c-afad-9521b8e48f50"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("7072a38f-5eda-4d27-8df3-d26aff252d35"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("78f7af9d-961b-4ba9-8b20-20ae118b16c6"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("873dbef2-761a-4010-8e71-1637b791603d"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("8ee03cf8-12ae-4040-933b-8d4fa1893131"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("d5bcdd99-b3a6-4c33-9886-ca5e643bf0a1"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("e626bf6b-d999-459b-9cff-82271cad1b48"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: new Guid("8c00ef67-3541-499b-aaf0-7597b9465466"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: new Guid("9be6d44f-c0bd-4821-a0f7-657eb75a29fe"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: new Guid("9c1b53da-63f7-4b60-9160-9edd5eaafb56"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: new Guid("cffc1e89-46b3-4efa-a6d4-3fbcfe6f3f91"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: new Guid("d6bbc62a-2662-4160-8b83-44c76aae92ba"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: new Guid("ef5a64aa-00fb-4b57-a946-869dcf988331"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: new Guid("f5296a48-bd21-4341-a462-50d327d3ee72"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ef0e2aff-84ad-4a3b-8486-6131eff68548"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("861f041d-6422-4734-a615-6ec5a95683ac"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("abc47c23-b9b5-495f-ad2d-67d0b8b598a4"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3319290d-7bc6-4f66-955e-0bff16902e4f"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("78575687-a6be-47fe-9fd9-7fa0dec32b66"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a2561418-c8a0-4451-9caf-2cc58c625d1e"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cb2e4c53-0754-487d-9bc2-8a8e5a5a8ff7"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d26859fa-798d-4341-b8c7-a2760b4b7522"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2174b77a-b7fe-4027-90a6-7f8bbd9cc062"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7ef1156c-4412-436c-a7e5-1c0d11b7da91"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d94a333b-96ba-4390-b69c-f6244560b421"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f65c980b-aca4-40d4-8179-3acbe852d4fd"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87209cbb-f1b3-45bb-a669-6c6741f6676f"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ef811dc4-971f-4db4-a7cf-72146baaa223"));

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "DisplayOrder", "ImageUrl", "IsActive", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Comfortable and stylish t-shirts for everyday wear", 1, "https://example.com/images/categories/tshirts.jpg", true, false, "T-Shirts", null },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Quality pants and trousers for all occasions", 2, "https://example.com/images/categories/pants.jpg", true, false, "Pants", null },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Elegant dresses for women", 3, "https://example.com/images/categories/dresses.jpg", true, false, "Dresses", null },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Fashion accessories to complete your look", 4, "https://example.com/images/categories/accessories.jpg", true, false, "Accessories", null }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                columns: new[] { "Id", "CreatedAt", "Description", "DurationInDays", "HasAIFeature", "IsActive", "IsDeleted", "MaxAIRequestsPerMonth", "MaxEditsPerModel", "MaxModels", "Name", "PlanType", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("cccccccc-0001-0001-0001-cccccccccccc"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói c? b?n 100.000 VND/tháng - Tr?i nghi?m tính n?ng AI c? b?n", 30, true, true, false, 20, 5, 3, "Gói C? B?n", 0, 100000m, null },
                    { new Guid("dddddddd-0002-0002-0002-dddddddddddd"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói nâng cao 250.000 VND/tháng - Tr?i nghi?m ??y ?? tính n?ng AI", 30, true, true, false, 100, 20, 10, "Gói Nâng Cao", 0, 250000m, null },
                    { new Guid("eeeeeeee-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói Stylist Pro hàng tháng - AI ?? xu?t màu s?c & phong cách, ch?nh s?a model gi?i h?n", 30, true, true, false, 50, 10, 5, "Stylist Pro Monthly", 0, 99000m, null },
                    { new Guid("eeeeeeee-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói Stylist Pro n?m - Ti?t ki?m 20%, AI ?? xu?t không gi?i h?n, ch?nh s?a model nhi?u h?n", 365, true, true, false, 200, 30, 20, "Stylist Pro Yearly", 0, 950000m, null },
                    { new Guid("ffffffff-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói c? b?n cho shop - 50 model ph?i ??, 10 l?n ch?nh s?a/model", 30, false, true, false, 0, 10, 50, "B2B Basic", 1, 499000m, null },
                    { new Guid("ffffffff-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói Pro cho shop - 200 model ph?i ??, 20 l?n ch?nh s?a/model, h? tr? ?u tiên", 30, false, true, false, 0, 20, 200, "B2B Pro", 1, 1490000m, null },
                    { new Guid("ffffffff-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói Enterprise cho shop - 1000 model ph?i ??, 50 l?n ch?nh s?a/model, API access", 30, false, true, false, 0, 50, 1000, "B2B Enterprise", 1, 4990000m, null }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "FullName", "IsActive", "IsDeleted", "IsVerified", "LogoUrl", "PasswordHash", "Phone", "Role", "ShopDescription", "ShopName", "TaxCode", "UpdatedAt", "WebsiteUrl" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "123 Admin Street, Ho Chi Minh City", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@fit3d.com", "Admin User", true, false, false, null, "AQAAAAIAAYagAAAAEJ8g1234567890abcdefghijklmnop", "0901234567", 1, null, null, null, null, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "456 Customer Lane, Ha Noi", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "nguyenvana@gmail.com", "Nguyen Van A", true, false, false, null, "AQAAAAIAAYagAAAAEJ8g1234567890abcdefghijklmnop", "0912345678", 0, null, null, null, null, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "789 Shopping Street, Da Nang", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tranthib@gmail.com", "Tran Thi B", true, false, false, null, "AQAAAAIAAYagAAAAEJ8g1234567890abcdefghijklmnop", "0923456789", 0, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "DeliveredAt", "DiscountAmount", "IsDeleted", "Note", "OrderNumber", "PaymentMethod", "PaymentStatus", "ReceiverName", "ReceiverPhone", "ShippedAt", "ShippingAddress", "ShippingFee", "Status", "TotalAmount", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("aaaa1111-1111-1111-1111-111111111111"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), 50000m, false, "Please call before delivery", "ORD-2024-0001", "COD", 1, "Nguyen Van A", "0912345678", new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), "456 Customer Lane, Ha Noi", 30000m, 4, 798000m, null, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbb2222-2222-2222-2222-222222222222"), new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "ORD-2024-0002", "VNPay", 1, "Tran Thi B", "0923456789", null, "789 Shopping Street, Da Nang", 0m, 2, 1130000m, null, new Guid("33333333-3333-3333-3333-333333333333") }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedAt", "Description", "ImageUrl", "IsActive", "IsDeleted", "IsFeatured", "ModelFilePath", "Name", "PreviewModelPath", "Price", "SKU", "SalePrice", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-aaaa-1111-aaaa-111111111111"), "Fit3D", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "A timeless classic cotton t-shirt with a comfortable fit. Perfect for casual wear.", "https://example.com/images/products/tshirt-classic.jpg", true, false, true, null, "Classic Cotton T-Shirt", null, 299000m, "TS-001", 249000m, 100, null },
                    { new Guid("22222222-aaaa-2222-aaaa-222222222222"), "Fit3D", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Elegant polo shirt made from premium cotton blend. Great for smart casual occasions.", "https://example.com/images/products/polo-premium.jpg", true, false, true, null, "Premium Polo Shirt", null, 450000m, "TS-002", null, 75, null },
                    { new Guid("33333333-bbbb-3333-bbbb-333333333333"), "Fit3D Denim", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Modern slim fit jeans with stretch for ultimate comfort. Available in multiple washes.", "https://example.com/images/products/jeans-slim.jpg", true, false, false, null, "Slim Fit Jeans", null, 650000m, "PT-001", 550000m, 50, null },
                    { new Guid("44444444-cccc-4444-cccc-444444444444"), "Fit3D Ladies", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Beautiful floral print summer dress. Light and breezy fabric perfect for warm days.", "https://example.com/images/products/dress-floral.jpg", true, false, true, null, "Floral Summer Dress", null, 780000m, "DR-001", 680000m, 30, null },
                    { new Guid("55555555-dddd-5555-dddd-555555555555"), "Fit3D Accessories", new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Genuine leather belt with classic buckle. Perfect accessory for any outfit.", "https://example.com/images/products/belt-leather.jpg", true, false, false, null, "Leather Belt", null, 350000m, "AC-001", null, 60, null }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "CartItems",
                columns: new[] { "Id", "Color", "CreatedAt", "IsDeleted", "ProductId", "Quantity", "Size", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("ca111111-1111-1111-1111-111111111111"), "Light Blue", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("22222222-aaaa-2222-aaaa-222222222222"), 1, "L", null, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("ca222222-2222-2222-2222-222222222222"), "Black", new DateTime(2024, 2, 16, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("11111111-aaaa-1111-aaaa-111111111111"), 3, "S", null, new Guid("33333333-3333-3333-3333-333333333333") }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "OrderItems",
                columns: new[] { "Id", "Color", "CreatedAt", "IsDeleted", "OrderId", "ProductId", "Quantity", "Size", "TotalPrice", "UnitPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("01111111-1111-1111-1111-111111111111"), "White", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("aaaa1111-1111-1111-1111-111111111111"), new Guid("11111111-aaaa-1111-aaaa-111111111111"), 2, "M", 498000m, 249000m, null },
                    { new Guid("02222222-2222-2222-2222-222222222222"), "Brown", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("aaaa1111-1111-1111-1111-111111111111"), new Guid("55555555-dddd-5555-dddd-555555555555"), 1, null, 350000m, 350000m, null },
                    { new Guid("03333333-3333-3333-3333-333333333333"), "Blue Wash", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("bbbb2222-2222-2222-2222-222222222222"), new Guid("33333333-bbbb-3333-bbbb-333333333333"), 1, "30", 550000m, 550000m, null },
                    { new Guid("04444444-4444-4444-4444-444444444444"), "Floral Pink", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("bbbb2222-2222-2222-2222-222222222222"), new Guid("44444444-cccc-4444-cccc-444444444444"), 1, "M", 680000m, 680000m, null }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "ProductColors",
                columns: new[] { "Id", "ColorCode", "ColorName", "CreatedAt", "ImageUrl", "IsDeleted", "ProductId", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-2222-1111-1111-111111111111"), "#4169E1", "Blue Wash", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("33333333-bbbb-3333-bbbb-333333333333"), 25, null },
                    { new Guid("22222222-2222-1111-1111-111111111111"), "#191970", "Dark Wash", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("33333333-bbbb-3333-bbbb-333333333333"), 25, null },
                    { new Guid("33333333-2222-1111-1111-111111111111"), "#FFB6C1", "Floral Pink", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("44444444-cccc-4444-cccc-444444444444"), 15, null },
                    { new Guid("44444444-2222-1111-1111-111111111111"), "#87CEEB", "Floral Blue", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("44444444-cccc-4444-cccc-444444444444"), 15, null },
                    { new Guid("55555555-2222-1111-1111-111111111111"), "#8B4513", "Brown", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("55555555-dddd-5555-dddd-555555555555"), 30, null },
                    { new Guid("66666666-2222-1111-1111-111111111111"), "#000000", "Black", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("55555555-dddd-5555-dddd-555555555555"), 30, null },
                    { new Guid("e1111111-1111-1111-1111-111111111111"), "#FFFFFF", "White", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("11111111-aaaa-1111-aaaa-111111111111"), 35, null },
                    { new Guid("e2222222-2222-2222-2222-222222222222"), "#000000", "Black", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("11111111-aaaa-1111-aaaa-111111111111"), 35, null },
                    { new Guid("e3333333-3333-3333-3333-333333333333"), "#000080", "Navy Blue", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("11111111-aaaa-1111-aaaa-111111111111"), 30, null },
                    { new Guid("f1111111-1111-1111-1111-111111111111"), "#FFFFFF", "White", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("22222222-aaaa-2222-aaaa-222222222222"), 25, null },
                    { new Guid("f2222222-2222-2222-2222-222222222222"), "#ADD8E6", "Light Blue", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("22222222-aaaa-2222-aaaa-222222222222"), 25, null },
                    { new Guid("f3333333-3333-3333-3333-333333333333"), "#FFC0CB", "Pink", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("22222222-aaaa-2222-aaaa-222222222222"), 25, null }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "ProductSizes",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "ProductId", "Size", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a1111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("11111111-aaaa-1111-aaaa-111111111111"), "S", 25, null },
                    { new Guid("a2222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("11111111-aaaa-1111-aaaa-111111111111"), "M", 30, null },
                    { new Guid("a3333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("11111111-aaaa-1111-aaaa-111111111111"), "L", 25, null },
                    { new Guid("a4444444-4444-4444-4444-444444444444"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("11111111-aaaa-1111-aaaa-111111111111"), "XL", 20, null },
                    { new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("22222222-aaaa-2222-aaaa-222222222222"), "S", 20, null },
                    { new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("22222222-aaaa-2222-aaaa-222222222222"), "M", 25, null },
                    { new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("22222222-aaaa-2222-aaaa-222222222222"), "L", 20, null },
                    { new Guid("c1111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("33333333-bbbb-3333-bbbb-333333333333"), "28", 10, null },
                    { new Guid("c2222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("33333333-bbbb-3333-bbbb-333333333333"), "30", 15, null },
                    { new Guid("c3333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("33333333-bbbb-3333-bbbb-333333333333"), "32", 15, null },
                    { new Guid("c4444444-4444-4444-4444-444444444444"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("33333333-bbbb-3333-bbbb-333333333333"), "34", 10, null },
                    { new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("44444444-cccc-4444-cccc-444444444444"), "S", 10, null },
                    { new Guid("d2222222-2222-2222-2222-222222222222"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("44444444-cccc-4444-cccc-444444444444"), "M", 12, null },
                    { new Guid("d3333333-3333-3333-3333-333333333333"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("44444444-cccc-4444-cccc-444444444444"), "L", 8, null }
                });
        }
    }
}
