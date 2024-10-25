using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class addingRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Seccion",
                table: "Grados",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GradoId",
                table: "Alumnos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grados_ProfesorId",
                table: "Grados",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_GradoId",
                table: "Alumnos",
                column: "GradoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_Grados_GradoId",
                table: "Alumnos",
                column: "GradoId",
                principalTable: "Grados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grados_Profesores_ProfesorId",
                table: "Grados",
                column: "ProfesorId",
                principalTable: "Profesores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_Grados_GradoId",
                table: "Alumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Grados_Profesores_ProfesorId",
                table: "Grados");

            migrationBuilder.DropIndex(
                name: "IX_Grados_ProfesorId",
                table: "Grados");

            migrationBuilder.DropIndex(
                name: "IX_Alumnos_GradoId",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "Seccion",
                table: "Grados");

            migrationBuilder.DropColumn(
                name: "GradoId",
                table: "Alumnos");
        }
    }
}
