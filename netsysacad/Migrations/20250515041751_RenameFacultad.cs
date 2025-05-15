using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netsysacad.Migrations
{
    /// <inheritdoc />
    public partial class RenameFacultad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autoridades_Facultad_FacultadId",
                table: "Autoridades");

            migrationBuilder.DropForeignKey(
                name: "FK_Facultad_Universidades_UniversidadId",
                table: "Facultad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facultad",
                table: "Facultad");

            migrationBuilder.RenameTable(
                name: "Facultad",
                newName: "Facultades");

            migrationBuilder.RenameIndex(
                name: "IX_Facultad_UniversidadId",
                table: "Facultades",
                newName: "IX_Facultades_UniversidadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facultades",
                table: "Facultades",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Autoridades_Facultades_FacultadId",
                table: "Autoridades",
                column: "FacultadId",
                principalTable: "Facultades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facultades_Universidades_UniversidadId",
                table: "Facultades",
                column: "UniversidadId",
                principalTable: "Universidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autoridades_Facultades_FacultadId",
                table: "Autoridades");

            migrationBuilder.DropForeignKey(
                name: "FK_Facultades_Universidades_UniversidadId",
                table: "Facultades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facultades",
                table: "Facultades");

            migrationBuilder.RenameTable(
                name: "Facultades",
                newName: "Facultad");

            migrationBuilder.RenameIndex(
                name: "IX_Facultades_UniversidadId",
                table: "Facultad",
                newName: "IX_Facultad_UniversidadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facultad",
                table: "Facultad",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Autoridades_Facultad_FacultadId",
                table: "Autoridades",
                column: "FacultadId",
                principalTable: "Facultad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facultad_Universidades_UniversidadId",
                table: "Facultad",
                column: "UniversidadId",
                principalTable: "Universidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
