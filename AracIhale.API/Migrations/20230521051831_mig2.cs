using Microsoft.EntityFrameworkCore.Migrations;

namespace AracIhale.API.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracModels_AracMarkas_AracMarkaID",
                table: "AracModels");

            migrationBuilder.DropForeignKey(
                name: "FK_AracOzellik_AracMarkas_AracMarkaID",
                table: "AracOzellik");

            migrationBuilder.DropForeignKey(
                name: "FK_AracOzellik_AracModels_AracModelID",
                table: "AracOzellik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AracModels",
                table: "AracModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AracMarkas",
                table: "AracMarkas");

            migrationBuilder.RenameTable(
                name: "AracModels",
                newName: "AracModel");

            migrationBuilder.RenameTable(
                name: "AracMarkas",
                newName: "AracMarka");

            migrationBuilder.RenameIndex(
                name: "IX_AracModels_AracMarkaID",
                table: "AracModel",
                newName: "IX_AracModel_AracMarkaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AracModel",
                table: "AracModel",
                column: "AracModelID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AracMarka",
                table: "AracMarka",
                column: "MarkaID");

            migrationBuilder.AddForeignKey(
                name: "FK_AracModel_AracMarka_AracMarkaID",
                table: "AracModel",
                column: "AracMarkaID",
                principalTable: "AracMarka",
                principalColumn: "MarkaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AracOzellik_AracMarka_AracMarkaID",
                table: "AracOzellik",
                column: "AracMarkaID",
                principalTable: "AracMarka",
                principalColumn: "MarkaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AracOzellik_AracModel_AracModelID",
                table: "AracOzellik",
                column: "AracModelID",
                principalTable: "AracModel",
                principalColumn: "AracModelID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AracModel_AracMarka_AracMarkaID",
                table: "AracModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AracOzellik_AracMarka_AracMarkaID",
                table: "AracOzellik");

            migrationBuilder.DropForeignKey(
                name: "FK_AracOzellik_AracModel_AracModelID",
                table: "AracOzellik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AracModel",
                table: "AracModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AracMarka",
                table: "AracMarka");

            migrationBuilder.RenameTable(
                name: "AracModel",
                newName: "AracModels");

            migrationBuilder.RenameTable(
                name: "AracMarka",
                newName: "AracMarkas");

            migrationBuilder.RenameIndex(
                name: "IX_AracModel_AracMarkaID",
                table: "AracModels",
                newName: "IX_AracModels_AracMarkaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AracModels",
                table: "AracModels",
                column: "AracModelID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AracMarkas",
                table: "AracMarkas",
                column: "MarkaID");

            migrationBuilder.AddForeignKey(
                name: "FK_AracModels_AracMarkas_AracMarkaID",
                table: "AracModels",
                column: "AracMarkaID",
                principalTable: "AracMarkas",
                principalColumn: "MarkaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AracOzellik_AracMarkas_AracMarkaID",
                table: "AracOzellik",
                column: "AracMarkaID",
                principalTable: "AracMarkas",
                principalColumn: "MarkaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AracOzellik_AracModels_AracModelID",
                table: "AracOzellik",
                column: "AracModelID",
                principalTable: "AracModels",
                principalColumn: "AracModelID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
