using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubMembershipApplication_DelegatesTutorial2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    Contraseña = table.Column<string>(type: "TEXT", nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NumeroDeTelefono = table.Column<string>(type: "TEXT", nullable: false),
                    PrimeraDireccionPostal = table.Column<string>(type: "TEXT", nullable: false),
                    SegundaDireccionPostal = table.Column<string>(type: "TEXT", nullable: false),
                    DIreccionDeLaCiudad = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroPostal = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
