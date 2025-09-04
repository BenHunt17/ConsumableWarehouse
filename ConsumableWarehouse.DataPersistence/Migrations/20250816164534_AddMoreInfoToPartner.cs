using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsumableWarehouse.DataPersistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreInfoToPartner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TradingName",
                table: "Partners",
                type: "nvarchar(99)",
                maxLength: 99,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VatNumber",
                table: "Partners",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TradingName",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "VatNumber",
                table: "Partners");
        }
    }
}
