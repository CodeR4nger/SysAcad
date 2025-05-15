using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace netsysacad.Migrations
{
    /// <inheritdoc />
    public partial class AddOrientacion_UpdateMateria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orientaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    EspecialidadId = table.Column<int>(type: "integer", nullable: false),
                    PlanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orientaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orientaciones_Especialidades_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orientaciones_Planes_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Planes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MateriaOrientacion",
                columns: table => new
                {
                    MateriasId = table.Column<int>(type: "integer", nullable: false),
                    OrientacionesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaOrientacion", x => new { x.MateriasId, x.OrientacionesId });
                    table.ForeignKey(
                        name: "FK_MateriaOrientacion_Materias_MateriasId",
                        column: x => x.MateriasId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MateriaOrientacion_Orientaciones_OrientacionesId",
                        column: x => x.OrientacionesId,
                        principalTable: "Orientaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MateriaOrientacion_OrientacionesId",
                table: "MateriaOrientacion",
                column: "OrientacionesId");

            migrationBuilder.CreateIndex(
                name: "IX_Orientaciones_EspecialidadId",
                table: "Orientaciones",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Orientaciones_PlanId",
                table: "Orientaciones",
                column: "PlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriaOrientacion");

            migrationBuilder.DropTable(
                name: "Orientaciones");
        }
    }
}
