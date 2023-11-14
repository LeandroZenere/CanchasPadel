using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class prueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Estado_EstadoId",
                table: "Reserva");

            migrationBuilder.RenameColumn(
                name: "EstadoId",
                table: "Reserva",
                newName: "idEstado");

            migrationBuilder.RenameIndex(
                name: "IX_Reserva_EstadoId",
                table: "Reserva",
                newName: "IX_Reserva_idEstado");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Estado_idEstado",
                table: "Reserva",
                column: "idEstado",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Estado_idEstado",
                table: "Reserva");

            migrationBuilder.RenameColumn(
                name: "idEstado",
                table: "Reserva",
                newName: "EstadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Reserva_idEstado",
                table: "Reserva",
                newName: "IX_Reserva_EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Estado_EstadoId",
                table: "Reserva",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
