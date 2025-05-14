using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace netsysacad.Migrations
{
    /// <inheritdoc />
    public partial class AutoridadAndRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Autoridades");

            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                table: "Autoridades",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoriasCargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasCargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDedicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    Observacion = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDedicacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    Puntos = table.Column<int>(type: "integer", nullable: false),
                    CategoriaCargoId = table.Column<int>(type: "integer", nullable: false),
                    TipoDedicacionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargos_CategoriasCargo_CategoriaCargoId",
                        column: x => x.CategoriaCargoId,
                        principalTable: "CategoriasCargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cargos_TiposDedicacion_TipoDedicacionId",
                        column: x => x.TipoDedicacionId,
                        principalTable: "TiposDedicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autoridades_CargoId",
                table: "Autoridades",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_CategoriaCargoId",
                table: "Cargos",
                column: "CategoriaCargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_TipoDedicacionId",
                table: "Cargos",
                column: "TipoDedicacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autoridades_Cargos_CargoId",
                table: "Autoridades",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autoridades_Cargos_CargoId",
                table: "Autoridades");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "CategoriasCargo");

            migrationBuilder.DropTable(
                name: "TiposDedicacion");

            migrationBuilder.DropIndex(
                name: "IX_Autoridades_CargoId",
                table: "Autoridades");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Autoridades");

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Autoridades",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
