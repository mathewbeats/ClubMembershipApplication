using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubMembershipApplication_DelegatesTutorial2.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailAddressToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SegundaDireccionPostal",
                table: "Usuarios",
                newName: "PostCode");

            migrationBuilder.RenameColumn(
                name: "PrimeraDireccionPostal",
                table: "Usuarios",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "NumeroPostal",
                table: "Usuarios",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "NumeroDeTelefono",
                table: "Usuarios",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Usuarios",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "FechaDeNacimiento",
                table: "Usuarios",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "DIreccionDeLaCiudad",
                table: "Usuarios",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "Contraseña",
                table: "Usuarios",
                newName: "AddressSecondLine");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "Usuarios",
                newName: "AddressFirstLine");

            migrationBuilder.AddColumn<string>(
                name: "AddressCity",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressCity",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "PostCode",
                table: "Usuarios",
                newName: "SegundaDireccionPostal");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Usuarios",
                newName: "PrimeraDireccionPostal");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuarios",
                newName: "NumeroPostal");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Usuarios",
                newName: "NumeroDeTelefono");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Usuarios",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Usuarios",
                newName: "FechaDeNacimiento");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Usuarios",
                newName: "DIreccionDeLaCiudad");

            migrationBuilder.RenameColumn(
                name: "AddressSecondLine",
                table: "Usuarios",
                newName: "Contraseña");

            migrationBuilder.RenameColumn(
                name: "AddressFirstLine",
                table: "Usuarios",
                newName: "Apellido");
        }
    }
}
