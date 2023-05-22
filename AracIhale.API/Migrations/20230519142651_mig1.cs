using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AracIhale.API.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AracMarkas",
                columns: table => new
                {
                    MarkaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracMarkas", x => x.MarkaID);
                });

            migrationBuilder.CreateTable(
                name: "BireyselKurumsal",
                columns: table => new
                {
                    BireselKurumsalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BireyselKurumsal", x => x.BireselKurumsalID);
                });

            migrationBuilder.CreateTable(
                name: "IhaleStatu",
                columns: table => new
                {
                    IhaleStatuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IhaleStatuAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IhaleStatu", x => x.IhaleStatuID);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "AracModels",
                columns: table => new
                {
                    AracModelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AracMarkaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracModels", x => x.AracModelID);
                    table.ForeignKey(
                        name: "FK_AracModels_AracMarkas_AracMarkaID",
                        column: x => x.AracMarkaID,
                        principalTable: "AracMarkas",
                        principalColumn: "MarkaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AktifPasifID = table.Column<int>(type: "int", nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RolID = table.Column<int>(type: "int", nullable: true),
                    BireyselKurumsalID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.KullaniciID);
                    table.ForeignKey(
                        name: "FK_Kullanici_BireyselKurumsal_BireyselKurumsalID",
                        column: x => x.BireyselKurumsalID,
                        principalTable: "BireyselKurumsal",
                        principalColumn: "BireselKurumsalID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kullanici_Rol_RolID",
                        column: x => x.RolID,
                        principalTable: "Rol",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AracOzellik",
                columns: table => new
                {
                    AracOzellikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AracMarkaID = table.Column<int>(type: "int", nullable: true),
                    YilID = table.Column<int>(type: "int", nullable: true),
                    AracModelID = table.Column<int>(type: "int", nullable: true),
                    GovdeTipiID = table.Column<int>(type: "int", nullable: true),
                    YakitTipiID = table.Column<int>(type: "int", nullable: true),
                    VitesTipiID = table.Column<int>(type: "int", nullable: true),
                    Versiyon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RenkID = table.Column<int>(type: "int", nullable: true),
                    OpsiyonelDonanim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AracOzellik", x => x.AracOzellikID);
                    table.ForeignKey(
                        name: "FK_AracOzellik_AracMarkas_AracMarkaID",
                        column: x => x.AracMarkaID,
                        principalTable: "AracMarkas",
                        principalColumn: "MarkaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AracOzellik_AracModels_AracModelID",
                        column: x => x.AracModelID,
                        principalTable: "AracModels",
                        principalColumn: "AracModelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Araclar",
                columns: table => new
                {
                    AracID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BireyselKurumsalID = table.Column<int>(type: "int", nullable: true),
                    KurumsalSirketAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StatuID = table.Column<int>(type: "int", nullable: true),
                    AracFiyati = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AracOzellikID = table.Column<int>(type: "int", nullable: true),
                    KMBilgisi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Donanim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KullaniciID = table.Column<int>(type: "int", nullable: true),
                    AracaPlaka = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araclar", x => x.AracID);
                    table.ForeignKey(
                        name: "FK_Araclar_AracOzellik_AracOzellikID",
                        column: x => x.AracOzellikID,
                        principalTable: "AracOzellik",
                        principalColumn: "AracOzellikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Araclar_BireyselKurumsal_BireyselKurumsalID",
                        column: x => x.BireyselKurumsalID,
                        principalTable: "BireyselKurumsal",
                        principalColumn: "BireselKurumsalID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Araclar_Kullanici_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IhaleListesi",
                columns: table => new
                {
                    IhaleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IhaleAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BireyselKurumsalID = table.Column<int>(type: "int", nullable: true),
                    KurumsalSirketAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IhaleStatuID = table.Column<int>(type: "int", nullable: true),
                    IhaleBaslangicTarihi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IhaleBaslangicSaati = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IhaleBitisTarihi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IhaleBitisSaati = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AracID = table.Column<int>(type: "int", nullable: true),
                    IhaleBaslangicFiyati = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MinimumAlimFiyati = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AracOzellikID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IhaleListesi", x => x.IhaleID);
                    table.ForeignKey(
                        name: "FK_IhaleListesi_Araclar_AracID",
                        column: x => x.AracID,
                        principalTable: "Araclar",
                        principalColumn: "AracID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IhaleListesi_AracOzellik_AracOzellikID",
                        column: x => x.AracOzellikID,
                        principalTable: "AracOzellik",
                        principalColumn: "AracOzellikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IhaleListesi_BireyselKurumsal_BireyselKurumsalID",
                        column: x => x.BireyselKurumsalID,
                        principalTable: "BireyselKurumsal",
                        principalColumn: "BireselKurumsalID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IhaleListesi_IhaleStatu_IhaleStatuID",
                        column: x => x.IhaleStatuID,
                        principalTable: "IhaleStatu",
                        principalColumn: "IhaleStatuID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IhaleTeklif",
                columns: table => new
                {
                    TeklifID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciID = table.Column<int>(type: "int", nullable: true),
                    TeklifFiyati = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TeklifTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IhaleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IhaleTeklif", x => x.TeklifID);
                    table.ForeignKey(
                        name: "FK_IhaleTeklif_IhaleListesi_IhaleID",
                        column: x => x.IhaleID,
                        principalTable: "IhaleListesi",
                        principalColumn: "IhaleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IhaleTeklif_Kullanici_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnaylananTeklif",
                columns: table => new
                {
                    OnaylananTeklifID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeklifID = table.Column<int>(type: "int", nullable: true),
                    KullaniciID = table.Column<int>(type: "int", nullable: true),
                    IhaleID = table.Column<int>(type: "int", nullable: true),
                    OnaylanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TeklifFiyati = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnaylananTeklif", x => x.OnaylananTeklifID);
                    table.ForeignKey(
                        name: "FK_OnaylananTeklif_IhaleListesi_IhaleID",
                        column: x => x.IhaleID,
                        principalTable: "IhaleListesi",
                        principalColumn: "IhaleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnaylananTeklif_IhaleTeklif_TeklifID",
                        column: x => x.TeklifID,
                        principalTable: "IhaleTeklif",
                        principalColumn: "TeklifID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnaylananTeklif_Kullanici_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_AracOzellikID",
                table: "Araclar",
                column: "AracOzellikID");

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_BireyselKurumsalID",
                table: "Araclar",
                column: "BireyselKurumsalID");

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_KullaniciID",
                table: "Araclar",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_AracModels_AracMarkaID",
                table: "AracModels",
                column: "AracMarkaID");

            migrationBuilder.CreateIndex(
                name: "IX_AracOzellik_AracMarkaID",
                table: "AracOzellik",
                column: "AracMarkaID");

            migrationBuilder.CreateIndex(
                name: "IX_AracOzellik_AracModelID",
                table: "AracOzellik",
                column: "AracModelID");

            migrationBuilder.CreateIndex(
                name: "IX_IhaleListesi_AracID",
                table: "IhaleListesi",
                column: "AracID");

            migrationBuilder.CreateIndex(
                name: "IX_IhaleListesi_AracOzellikID",
                table: "IhaleListesi",
                column: "AracOzellikID");

            migrationBuilder.CreateIndex(
                name: "IX_IhaleListesi_BireyselKurumsalID",
                table: "IhaleListesi",
                column: "BireyselKurumsalID");

            migrationBuilder.CreateIndex(
                name: "IX_IhaleListesi_IhaleStatuID",
                table: "IhaleListesi",
                column: "IhaleStatuID");

            migrationBuilder.CreateIndex(
                name: "IX_IhaleTeklif_IhaleID",
                table: "IhaleTeklif",
                column: "IhaleID");

            migrationBuilder.CreateIndex(
                name: "IX_IhaleTeklif_KullaniciID",
                table: "IhaleTeklif",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanici_BireyselKurumsalID",
                table: "Kullanici",
                column: "BireyselKurumsalID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanici_RolID",
                table: "Kullanici",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_OnaylananTeklif_IhaleID",
                table: "OnaylananTeklif",
                column: "IhaleID");

            migrationBuilder.CreateIndex(
                name: "IX_OnaylananTeklif_KullaniciID",
                table: "OnaylananTeklif",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_OnaylananTeklif_TeklifID",
                table: "OnaylananTeklif",
                column: "TeklifID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnaylananTeklif");

            migrationBuilder.DropTable(
                name: "IhaleTeklif");

            migrationBuilder.DropTable(
                name: "IhaleListesi");

            migrationBuilder.DropTable(
                name: "Araclar");

            migrationBuilder.DropTable(
                name: "IhaleStatu");

            migrationBuilder.DropTable(
                name: "AracOzellik");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "AracModels");

            migrationBuilder.DropTable(
                name: "BireyselKurumsal");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "AracMarkas");
        }
    }
}
