using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIt3d.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDeviceInfoFromAIUsageLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                schema: "fit3d",
                table: "AIUsageLogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                schema: "fit3d",
                table: "AIUsageLogs",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
