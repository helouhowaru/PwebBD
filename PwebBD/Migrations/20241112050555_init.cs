using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PwebBD.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pwebdb");

            migrationBuilder.CreateTable(
                name: "estado",
                schema: "pwebdb",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado_IdEstado", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "imgsquinta",
                schema: "pwebdb",
                columns: table => new
                {
                    IdImg = table.Column<int>(type: "int", nullable: false),
                    ImgQuinta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imgsquinta_IdImg", x => x.IdImg);
                });

            migrationBuilder.CreateTable(
                name: "redessociales",
                schema: "pwebdb",
                columns: table => new
                {
                    IdRedes = table.Column<int>(type: "int", nullable: false),
                    RedSoc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_redessociales_IdRedes", x => x.IdRedes);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                schema: "pwebdb",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    rol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol_IdRol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "quinta",
                schema: "pwebdb",
                columns: table => new
                {
                    IdQuinta = table.Column<int>(type: "int", nullable: false),
                    PrecioPorPersona = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdRedes = table.Column<int>(type: "int", nullable: false),
                    IdImagen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quinta_IdQuinta", x => x.IdQuinta);
                    table.ForeignKey(
                        name: "quinta$quinta_ibfk_1",
                        column: x => x.IdImagen,
                        principalSchema: "pwebdb",
                        principalTable: "imgsquinta",
                        principalColumn: "IdImg");
                    table.ForeignKey(
                        name: "quinta$quinta_ibfk_2",
                        column: x => x.IdRedes,
                        principalSchema: "pwebdb",
                        principalTable: "redessociales",
                        principalColumn: "IdRedes");
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                schema: "pwebdb",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    contraseña = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_IdUsuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "usuario$usuario_ibfk_1",
                        column: x => x.IdRol,
                        principalSchema: "pwebdb",
                        principalTable: "rol",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "datosreservacion",
                schema: "pwebdb",
                columns: table => new
                {
                    IdReservacion = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    NumInvitados = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdQuinta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datosreservacion_IdReservacion", x => x.IdReservacion);
                    table.ForeignKey(
                        name: "datosreservacion$datosreservacion_ibfk_2",
                        column: x => x.IdUsuario,
                        principalSchema: "pwebdb",
                        principalTable: "usuario",
                        principalColumn: "IdUsuario");
                    table.ForeignKey(
                        name: "datosreservacion$datosreservacion_ibfk_3",
                        column: x => x.IdEstado,
                        principalSchema: "pwebdb",
                        principalTable: "estado",
                        principalColumn: "IdEstado");
                    table.ForeignKey(
                        name: "datosreservacion$datosreservacion_ibfk_4",
                        column: x => x.IdQuinta,
                        principalSchema: "pwebdb",
                        principalTable: "quinta",
                        principalColumn: "IdQuinta");
                });

            migrationBuilder.CreateIndex(
                name: "IdEstado",
                schema: "pwebdb",
                table: "datosreservacion",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IdQuinta",
                schema: "pwebdb",
                table: "datosreservacion",
                column: "IdQuinta");

            migrationBuilder.CreateIndex(
                name: "IdUsuario",
                schema: "pwebdb",
                table: "datosreservacion",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IdImagen",
                schema: "pwebdb",
                table: "quinta",
                column: "IdImagen");

            migrationBuilder.CreateIndex(
                name: "IdRedes",
                schema: "pwebdb",
                table: "quinta",
                column: "IdRedes");

            migrationBuilder.CreateIndex(
                name: "PrecioReservacion",
                schema: "pwebdb",
                table: "quinta",
                column: "PrecioPorPersona");

            migrationBuilder.CreateIndex(
                name: "IdRol",
                schema: "pwebdb",
                table: "usuario",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "datosreservacion",
                schema: "pwebdb");

            migrationBuilder.DropTable(
                name: "usuario",
                schema: "pwebdb");

            migrationBuilder.DropTable(
                name: "estado",
                schema: "pwebdb");

            migrationBuilder.DropTable(
                name: "quinta",
                schema: "pwebdb");

            migrationBuilder.DropTable(
                name: "rol",
                schema: "pwebdb");

            migrationBuilder.DropTable(
                name: "imgsquinta",
                schema: "pwebdb");

            migrationBuilder.DropTable(
                name: "redessociales",
                schema: "pwebdb");
        }
    }
}
