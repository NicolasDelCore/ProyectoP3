using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcosistemasMarinos.LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosConservacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UltimoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoPorcentual = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosConservacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UltimoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alfa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UltimoId = table.Column<int>(type: "int", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UltimoId = table.Column<int>(type: "int", nullable: false),
                    NombreCientifico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreVulgar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RangoTamano_PesoMinimo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RangoTamano_PesoMaximo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RangoTamano_LongitudMinima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RangoTamano_LongitudMaxima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstadoConservacionId = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especies_EstadosConservacion_EstadoConservacionId",
                        column: x => x.EstadoConservacionId,
                        principalTable: "EstadosConservacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ecosistemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UltimoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubicacion_Latitud = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ubicacion_Longitud = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    EstadoConservacionId = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecosistemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ecosistemas_EstadosConservacion_EstadoConservacionId",
                        column: x => x.EstadoConservacionId,
                        principalTable: "EstadosConservacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ecosistemas_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Amenazas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UltimoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grado = table.Column<int>(type: "int", nullable: false),
                    EcosistemaId = table.Column<int>(type: "int", nullable: true),
                    EspecieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenazas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenazas_Ecosistemas_EcosistemaId",
                        column: x => x.EcosistemaId,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Amenazas_Especies_EspecieId",
                        column: x => x.EspecieId,
                        principalTable: "Especies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EspeciesQueHabitan",
                columns: table => new
                {
                    EcosistemasQueHabitanId = table.Column<int>(type: "int", nullable: false),
                    EspeciesQueHabitanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspeciesQueHabitan", x => new { x.EcosistemasQueHabitanId, x.EspeciesQueHabitanId });
                    table.ForeignKey(
                        name: "FK_EspeciesQueHabitan_Ecosistemas_EcosistemasQueHabitanId",
                        column: x => x.EcosistemasQueHabitanId,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EspeciesQueHabitan_Especies_EspeciesQueHabitanId",
                        column: x => x.EspeciesQueHabitanId,
                        principalTable: "Especies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EspeciesQuePuedenHabitar",
                columns: table => new
                {
                    EcosistemasQuePuedenHabitarId = table.Column<int>(type: "int", nullable: false),
                    EspeciesQuePuedenHabitarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspeciesQuePuedenHabitar", x => new { x.EcosistemasQuePuedenHabitarId, x.EspeciesQuePuedenHabitarId });
                    table.ForeignKey(
                        name: "FK_EspeciesQuePuedenHabitar_Ecosistemas_EcosistemasQuePuedenHabitarId",
                        column: x => x.EcosistemasQuePuedenHabitarId,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EspeciesQuePuedenHabitar_Especies_EspeciesQuePuedenHabitarId",
                        column: x => x.EspeciesQuePuedenHabitarId,
                        principalTable: "Especies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amenazas_EcosistemaId",
                table: "Amenazas",
                column: "EcosistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Amenazas_EspecieId",
                table: "Amenazas",
                column: "EspecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_EstadoConservacionId",
                table: "Ecosistemas",
                column: "EstadoConservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_PaisId",
                table: "Ecosistemas",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Especies_EstadoConservacionId",
                table: "Especies",
                column: "EstadoConservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EspeciesQueHabitan_EspeciesQueHabitanId",
                table: "EspeciesQueHabitan",
                column: "EspeciesQueHabitanId");

            migrationBuilder.CreateIndex(
                name: "IX_EspeciesQuePuedenHabitar_EspeciesQuePuedenHabitarId",
                table: "EspeciesQuePuedenHabitar",
                column: "EspeciesQuePuedenHabitarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenazas");

            migrationBuilder.DropTable(
                name: "EspeciesQueHabitan");

            migrationBuilder.DropTable(
                name: "EspeciesQuePuedenHabitar");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ecosistemas");

            migrationBuilder.DropTable(
                name: "Especies");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "EstadosConservacion");
        }
    }
}
