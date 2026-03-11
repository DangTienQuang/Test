using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FIt3d.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSubscriptionPaymentPlans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                columns: new[] { "Id", "CreatedAt", "Description", "DurationInDays", "HasAIFeature", "IsActive", "IsDeleted", "MaxAIRequestsPerMonth", "MaxEditsPerModel", "MaxModels", "Name", "PlanType", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("f5296a48-bd21-4341-a462-50d327d3ee72"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói c? b?n 100.000 VND/tháng - Tr?i nghi?m tính n?ng AI c? b?n", 30, true, true, false, 20, 5, 3, "Gói C? B?n", 0, 100000m, null },
                    { new Guid("9be6d44f-c0bd-4821-a0f7-657eb75a29fe"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói nâng cao 200.000 VND/tháng - Tr?i nghi?m ??y ?? tính n?ng AI", 30, true, true, false, 100, 20, 10, "Gói Nâng Cao", 0, 200000m, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: new Guid("f5296a48-bd21-4341-a462-50d327d3ee72"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: new Guid("9be6d44f-c0bd-4821-a0f7-657eb75a29fe"));
        }
    }
}
