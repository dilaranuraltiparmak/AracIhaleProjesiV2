using Microsoft.EntityFrameworkCore.Migrations;

namespace AracIhale.API.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MarkaAdi",
                table: "IhaleListesi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelAdi",
                table: "IhaleListesi",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarkaAdi",
                table: "IhaleListesi");

            migrationBuilder.DropColumn(
                name: "ModelAdi",
                table: "IhaleListesi");
        }
    }
}
