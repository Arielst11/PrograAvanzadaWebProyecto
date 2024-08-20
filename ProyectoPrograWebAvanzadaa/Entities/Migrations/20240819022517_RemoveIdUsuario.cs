using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIdUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Nota",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Asistencia",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Nota",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Asistencia",
                newName: "IdUsuario");

            migrationBuilder.AddColumn<string>(
                name: "IdUsuario",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
