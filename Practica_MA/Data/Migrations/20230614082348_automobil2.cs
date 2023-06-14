using Microsoft.EntityFrameworkCore.Migrations;

namespace Practica_MA.Data.Migrations
{
    public partial class automobil2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imgURL",
                table: "Automobil",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgURL",
                table: "Automobil");
        }
    }
}
