using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class idPersonaAgg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idPersona",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_idPersona",
                table: "Reserva",
                column: "idPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Persona_idPersona",
                table: "Reserva",
                column: "idPersona",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Persona_idPersona",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_idPersona",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "idPersona",
                table: "Reserva");
        }
    }
}
