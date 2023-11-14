using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class tablas6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Cancha");

            migrationBuilder.AddColumn<bool>(
                name: "Disponible",
                table: "Cancha",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Cancha",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponible",
                table: "Cancha");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Cancha");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Cancha",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
