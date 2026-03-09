using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIt3d.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAIUsageLogForAccountTracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AIUsageLogs_Subscriptions_SubscriptionId",
                schema: "fit3d",
                table: "AIUsageLogs");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                schema: "fit3d",
                table: "AIUsageLogs");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubscriptionId",
                schema: "fit3d",
                table: "AIUsageLogs",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "AIResponse",
                schema: "fit3d",
                table: "AIUsageLogs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceInfo",
                schema: "fit3d",
                table: "AIUsageLogs",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                schema: "fit3d",
                table: "AIUsageLogs",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TokensUsed",
                schema: "fit3d",
                table: "AIUsageLogs",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "fit3d",
                table: "AIUsageLogs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserPrompt",
                schema: "fit3d",
                table: "AIUsageLogs",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIUsageLogs_UserId",
                schema: "fit3d",
                table: "AIUsageLogs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AIUsageLogs_Subscriptions_SubscriptionId",
                schema: "fit3d",
                table: "AIUsageLogs",
                column: "SubscriptionId",
                principalSchema: "fit3d",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AIUsageLogs_Users_UserId",
                schema: "fit3d",
                table: "AIUsageLogs",
                column: "UserId",
                principalSchema: "fit3d",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AIUsageLogs_Subscriptions_SubscriptionId",
                schema: "fit3d",
                table: "AIUsageLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_AIUsageLogs_Users_UserId",
                schema: "fit3d",
                table: "AIUsageLogs");

            migrationBuilder.DropIndex(
                name: "IX_AIUsageLogs_UserId",
                schema: "fit3d",
                table: "AIUsageLogs");

            migrationBuilder.DropColumn(
                name: "AIResponse",
                schema: "fit3d",
                table: "AIUsageLogs");

            migrationBuilder.DropColumn(
                name: "DeviceInfo",
                schema: "fit3d",
                table: "AIUsageLogs");

            migrationBuilder.DropColumn(
                name: "SessionId",
                schema: "fit3d",
                table: "AIUsageLogs");

            migrationBuilder.DropColumn(
                name: "TokensUsed",
                schema: "fit3d",
                table: "AIUsageLogs");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "fit3d",
                table: "AIUsageLogs");

            migrationBuilder.DropColumn(
                name: "UserPrompt",
                schema: "fit3d",
                table: "AIUsageLogs");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubscriptionId",
                schema: "fit3d",
                table: "AIUsageLogs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                schema: "fit3d",
                table: "AIUsageLogs",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AIUsageLogs_Subscriptions_SubscriptionId",
                schema: "fit3d",
                table: "AIUsageLogs",
                column: "SubscriptionId",
                principalSchema: "fit3d",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
