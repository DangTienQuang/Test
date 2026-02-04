using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FIt3d.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSubscriptionFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                schema: "fit3d",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                schema: "fit3d",
                table: "Users",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopDescription",
                schema: "fit3d",
                table: "Users",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShopName",
                schema: "fit3d",
                table: "Users",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxCode",
                schema: "fit3d",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebsiteUrl",
                schema: "fit3d",
                table: "Users",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubscriptionPlans",
                schema: "fit3d",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PlanType = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DurationInDays = table.Column<int>(type: "integer", nullable: false),
                    MaxModels = table.Column<int>(type: "integer", nullable: false),
                    MaxEditsPerModel = table.Column<int>(type: "integer", nullable: false),
                    MaxAIRequestsPerMonth = table.Column<int>(type: "integer", nullable: false),
                    HasAIFeature = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                schema: "fit3d",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscriptionPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    PaymentTransactionId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PaymentMethod = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    AIRequestsUsedThisMonth = table.Column<int>(type: "integer", nullable: false),
                    AIRequestsResetDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModelsUsed = table.Column<int>(type: "integer", nullable: false),
                    AutoRenew = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_SubscriptionPlans_SubscriptionPlanId",
                        column: x => x.SubscriptionPlanId,
                        principalSchema: "fit3d",
                        principalTable: "SubscriptionPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "fit3d",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AIUsageLogs",
                schema: "fit3d",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestType = table.Column<int>(type: "integer", nullable: false),
                    InputData = table.Column<string>(type: "text", nullable: true),
                    OutputData = table.Column<string>(type: "text", nullable: true),
                    ProcessingTimeMs = table.Column<int>(type: "integer", nullable: false),
                    IsSuccess = table.Column<bool>(type: "boolean", nullable: false),
                    ErrorMessage = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IpAddress = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIUsageLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AIUsageLogs_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "fit3d",
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                schema: "fit3d",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ModelFileUrl = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ConfigurationData = table.Column<string>(type: "text", nullable: true),
                    LinkedProductsData = table.Column<string>(type: "text", nullable: true),
                    FileSizeBytes = table.Column<long>(type: "bigint", nullable: false),
                    EditCount = table.Column<int>(type: "integer", nullable: false),
                    MaxEditCount = table.Column<int>(type: "integer", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "fit3d",
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                columns: new[] { "Id", "CreatedAt", "Description", "DurationInDays", "HasAIFeature", "IsActive", "IsDeleted", "MaxAIRequestsPerMonth", "MaxEditsPerModel", "MaxModels", "Name", "PlanType", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("eeeeeeee-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói Stylist Pro hàng tháng - AI ?? xu?t màu s?c & phong cách, ch?nh s?a model gi?i h?n", 30, true, true, false, 50, 10, 5, "Stylist Pro Monthly", 0, 99000m, null },
                    { new Guid("eeeeeeee-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói Stylist Pro n?m - Ti?t ki?m 20%, AI ?? xu?t không gi?i h?n, ch?nh s?a model nhi?u h?n", 365, true, true, false, 200, 30, 20, "Stylist Pro Yearly", 0, 950000m, null },
                    { new Guid("ffffffff-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói c? b?n cho shop - 50 model ph?i ??, 10 l?n ch?nh s?a/model", 30, false, true, false, 0, 10, 50, "B2B Basic", 1, 499000m, null },
                    { new Guid("ffffffff-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói Pro cho shop - 200 model ph?i ??, 20 l?n ch?nh s?a/model, h? tr? ?u tiên", 30, false, true, false, 0, 20, 200, "B2B Pro", 1, 1490000m, null },
                    { new Guid("ffffffff-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói Enterprise cho shop - 1000 model ph?i ??, 50 l?n ch?nh s?a/model, API access", 30, false, true, false, 0, 50, 1000, "B2B Enterprise", 1, 4990000m, null }
                });

            migrationBuilder.UpdateData(
                schema: "fit3d",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "IsVerified", "LogoUrl", "ShopDescription", "ShopName", "TaxCode", "WebsiteUrl" },
                values: new object[] { false, null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "fit3d",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "IsVerified", "LogoUrl", "ShopDescription", "ShopName", "TaxCode", "WebsiteUrl" },
                values: new object[] { false, null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "fit3d",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "IsVerified", "LogoUrl", "ShopDescription", "ShopName", "TaxCode", "WebsiteUrl" },
                values: new object[] { false, null, null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_AIUsageLogs_SubscriptionId",
                schema: "fit3d",
                table: "AIUsageLogs",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_SubscriptionId",
                schema: "fit3d",
                table: "Models",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriptionPlanId",
                schema: "fit3d",
                table: "Subscriptions",
                column: "SubscriptionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                schema: "fit3d",
                table: "Subscriptions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AIUsageLogs",
                schema: "fit3d");

            migrationBuilder.DropTable(
                name: "Models",
                schema: "fit3d");

            migrationBuilder.DropTable(
                name: "Subscriptions",
                schema: "fit3d");

            migrationBuilder.DropTable(
                name: "SubscriptionPlans",
                schema: "fit3d");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                schema: "fit3d",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                schema: "fit3d",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ShopDescription",
                schema: "fit3d",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ShopName",
                schema: "fit3d",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TaxCode",
                schema: "fit3d",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WebsiteUrl",
                schema: "fit3d",
                table: "Users");
        }
    }
}
