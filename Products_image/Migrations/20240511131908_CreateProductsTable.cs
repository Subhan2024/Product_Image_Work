using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products_image.Migrations
{
    /// <inheritdoc />
    public partial class CreateProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdPrice = table.Column<double>(type: "float", nullable: false),
                    ProdImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
