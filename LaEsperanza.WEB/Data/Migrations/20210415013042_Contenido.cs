using Microsoft.EntityFrameworkCore.Migrations;

namespace LaEsperanza.WEB.Data.Migrations
{
    public partial class Contenido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contenido",
                table: "Items",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contenido",
                table: "Items");
        }
    }
}
