using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsumableWarehouse.DataPersistence.Migrations
{
    /// <inheritdoc />
    public partial class AddExternalIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExternalId",
                table: "Wishlists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "WishlistProduct",
                type: "nvarchar(999)",
                maxLength: 999,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(999)",
                oldMaxLength: 999);

            migrationBuilder.AddColumn<Guid>(
                name: "ExternalId",
                table: "WishlistProduct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ExternalId",
                table: "AffiliateProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_ExternalId",
                table: "Wishlists",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishlistProduct_ExternalId",
                table: "WishlistProduct",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateProducts_ExternalId",
                table: "AffiliateProducts",
                column: "ExternalId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Wishlists_ExternalId",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_WishlistProduct_ExternalId",
                table: "WishlistProduct");

            migrationBuilder.DropIndex(
                name: "IX_AffiliateProducts_ExternalId",
                table: "AffiliateProducts");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "WishlistProduct");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "AffiliateProducts");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "WishlistProduct",
                type: "nvarchar(999)",
                maxLength: 999,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(999)",
                oldMaxLength: 999,
                oldNullable: true);
        }
    }
}
