using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GabiniBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class posreformulacao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "url_foto_perfil",
                table: "Usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "url_foto_perfil",
                table: "Usuarios");
        }
    }
}
