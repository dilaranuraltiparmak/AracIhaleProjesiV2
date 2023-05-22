using Microsoft.EntityFrameworkCore.Migrations;

namespace AracIhale.API.Migrations
{
    public partial class mig55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Araclar",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Araclar");
        }
    }
}
