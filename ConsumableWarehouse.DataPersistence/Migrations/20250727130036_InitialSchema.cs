using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsumableWarehouse.DataPersistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(99)", maxLength: 99, nullable: false),
                    ContactEmailAddress = table.Column<string>(type: "nvarchar(99)", maxLength: 99, nullable: false),
                    ContactPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(99)", maxLength: 99, nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(99)", maxLength: 99, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AffiliateProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(99)", maxLength: 99, nullable: false),
                    AffiliateLink = table.Column<string>(type: "nvarchar(999)", maxLength: 999, nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliateProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AffiliateProducts_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AffiliateProducts_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WishlistProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(999)", maxLength: 999, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    AffiliateProductId = table.Column<int>(type: "int", nullable: true),
                    WishlistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishlistProduct_AffiliateProducts_AffiliateProductId",
                        column: x => x.AffiliateProductId,
                        principalTable: "AffiliateProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WishlistProduct_Wishlists_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FreeTextProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", maxLength: 99, nullable: false),
                    WishlistProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeTextProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreeTextProduct_WishlistProduct_WishlistProductId",
                        column: x => x.WishlistProductId,
                        principalTable: "WishlistProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateProducts_Name",
                table: "AffiliateProducts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateProducts_PartnerId",
                table: "AffiliateProducts",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateProducts_ProductCategoryId",
                table: "AffiliateProducts",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FreeTextProduct_WishlistProductId",
                table: "FreeTextProduct",
                column: "WishlistProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partners_CompanyName",
                table: "Partners",
                column: "CompanyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_Name",
                table: "ProductCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentCategoryId",
                table: "ProductCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistProduct_AffiliateProductId",
                table: "WishlistProduct",
                column: "AffiliateProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistProduct_WishlistId",
                table: "WishlistProduct",
                column: "WishlistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FreeTextProduct");

            migrationBuilder.DropTable(
                name: "WishlistProduct");

            migrationBuilder.DropTable(
                name: "AffiliateProducts");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
