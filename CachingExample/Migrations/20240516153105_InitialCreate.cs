using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CachingExample.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Products",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Name = table.Column<string>(type: "TEXT", nullable: false),
                BasePrice = table.Column<float>(type: "REAL", nullable: false),
                Description = table.Column<string>(type: "TEXT", nullable: false),
                ImageName = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.Id);
            });

        migrationBuilder.InsertData(
            table: "Products",
            columns: new[] { "Id", "BasePrice", "Description", "ImageName", "Name" },
            values: new object[,]
            {
                { 1, 5.5f, "A spherical ball used in basketball games.", "basketball", "Basketball" },
                { 2, 2.5f, "Cupcake topped with Blue mysterious and delicous cream.", "blue-cupcake", "Blue cupcake" },
                { 3, 4f, "Chocolate cupcakes topped with chocolate frosting.", "chocolate-cupcake", "Chocolate cupcake" },
                { 4, 3f, "An orange cone that is used to be placed on roads or footpaths.", "traffic-cone", "Traffic cone" },
                { 5, 2f, "A ball inflated with air that is being played by using your feet.", "football", "Football" }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Products");
    }
}
