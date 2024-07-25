using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcosistemasMarinos.LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class eliminadoIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UltimoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UltimoId",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "UltimoId",
                table: "EstadosConservacion");

            migrationBuilder.DropColumn(
                name: "UltimoId",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "UltimoId",
                table: "Ecosistemas");

            migrationBuilder.DropColumn(
                name: "UltimoId",
                table: "Amenazas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UltimoId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UltimoId",
                table: "Paises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UltimoId",
                table: "EstadosConservacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UltimoId",
                table: "Especies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UltimoId",
                table: "Ecosistemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UltimoId",
                table: "Amenazas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
