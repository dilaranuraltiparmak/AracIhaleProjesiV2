using Microsoft.EntityFrameworkCore.Migrations;

namespace AracIhale.API.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MarkaID",
                table: "AracMarka",
                newName: "AracMarkaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AracMarkaID",
                table: "AracMarka",
                newName: "MarkaID");
        }
    }
}
