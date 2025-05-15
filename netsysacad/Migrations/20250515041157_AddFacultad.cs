using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace netsysacad.Migrations
{
    /// <inheritdoc />
    public partial class AddFacultad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacultadId",
                table: "Autoridades",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Facultad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    Abreviatura = table.Column<string>(type: "varchar(20)", nullable: false),
                    Directorio = table.Column<string>(type: "varchar(50)", nullable: false),
                    Sigla = table.Column<string>(type: "varchar(10)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "varchar(10)", nullable: false),
                    Ciudad = table.Column<string>(type: "varchar(50)", nullable: false),
                    Domicilio = table.Column<string>(type: "varchar(50)", nullable: false),
                    Telefono = table.Column<string>(type: "varchar(50)", nullable: false),
                    Contacto = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    UniversidadId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facultad_Universidades_UniversidadId",
                        column: x => x.UniversidadId,
                        principalTable: "Universidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autoridades_FacultadId",
                table: "Autoridades",
                column: "FacultadId");

            migrationBuilder.CreateIndex(
                name: "IX_Facultad_UniversidadId",
                table: "Facultad",
                column: "UniversidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autoridades_Facultad_FacultadId",
                table: "Autoridades",
                column: "FacultadId",
                principalTable: "Facultad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autoridades_Facultad_FacultadId",
                table: "Autoridades");

            migrationBuilder.DropTable(
                name: "Facultad");

            migrationBuilder.DropIndex(
                name: "IX_Autoridades_FacultadId",
                table: "Autoridades");

            migrationBuilder.DropColumn(
                name: "FacultadId",
                table: "Autoridades");
        }
    }
}
