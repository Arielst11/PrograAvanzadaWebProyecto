using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class New_Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdClase",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdClaseNavigationIdClase",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimerApellido",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SegundoApellido",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Asistencia",
                columns: table => new
                {
                    IdAsistencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: true),
                    AsistenciaUsuario = table.Column<bool>(type: "bit", nullable: true),
                    PorcentajeAsistencia = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdUsuarioNavigationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencia", x => x.IdAsistencia);
                    table.ForeignKey(
                        name: "FK_Asistencia_AspNetUsers_IdUsuarioNavigationId",
                        column: x => x.IdUsuarioNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clase",
                columns: table => new
                {
                    IdClase = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clase", x => x.IdClase);
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    IdTarea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTarea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescripcionTarea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorPorcentual = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.IdTarea);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    IdNota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdTarea = table.Column<int>(type: "int", nullable: true),
                    NotaTarea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTareaNavigationIdTarea = table.Column<int>(type: "int", nullable: true),
                    IdUsuarioNavigationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.IdNota);
                    table.ForeignKey(
                        name: "FK_Nota_AspNetUsers_IdUsuarioNavigationId",
                        column: x => x.IdUsuarioNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nota_Tarea_IdTareaNavigationIdTarea",
                        column: x => x.IdTareaNavigationIdTarea,
                        principalTable: "Tarea",
                        principalColumn: "IdTarea");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdClaseNavigationIdClase",
                table: "AspNetUsers",
                column: "IdClaseNavigationIdClase");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencia_IdUsuarioNavigationId",
                table: "Asistencia",
                column: "IdUsuarioNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_IdTareaNavigationIdTarea",
                table: "Nota",
                column: "IdTareaNavigationIdTarea");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_IdUsuarioNavigationId",
                table: "Nota",
                column: "IdUsuarioNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Clase_IdClaseNavigationIdClase",
                table: "AspNetUsers",
                column: "IdClaseNavigationIdClase",
                principalTable: "Clase",
                principalColumn: "IdClase");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Clase_IdClaseNavigationIdClase",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Asistencia");

            migrationBuilder.DropTable(
                name: "Clase");

            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdClaseNavigationIdClase",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdClase",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdClaseNavigationIdClase",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PrimerApellido",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SegundoApellido",
                table: "AspNetUsers");
        }
    }
}
