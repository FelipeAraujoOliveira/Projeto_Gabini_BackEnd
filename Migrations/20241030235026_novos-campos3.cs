using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GabiniBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class novoscampos3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "url_foto_perfil",
                table: "Usuarios",
                newName: "Url_foto_perfil");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url_foto_perfil",
                table: "Usuarios",
                newName: "url_foto_perfil");
        }
    }
}
