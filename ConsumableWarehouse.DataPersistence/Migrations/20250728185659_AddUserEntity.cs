using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsumableWarehouse.DataPersistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Wishlists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Wishlists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "Wishlists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "Wishlists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FreeTextProduct",
                type: "nvarchar(99)",
                maxLength: 99,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 99);

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdentityId = table.Column<string>(type: "nvarchar(99)", maxLength: 99, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(99)", maxLength: 99, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(99)", maxLength: 99, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(99)", maxLength: 99, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_UserProfileId_Name",
                table: "Wishlists",
                columns: new[] { "UserProfileId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserIdentityId",
                table: "UserProfiles",
                column: "UserIdentityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_UserProfiles_UserProfileId",
                table: "Wishlists",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_UserProfiles_UserProfileId",
                table: "Wishlists");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Wishlists_UserProfileId_Name",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Wishlists");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "FreeTextProduct",
                type: "int",
                maxLength: 99,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(99)",
                oldMaxLength: 99);
        }
    }
}
