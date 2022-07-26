using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameWatchAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BizneziKonzolaVideoloja");

            migrationBuilder.DropTable(
                name: "Cmimorja");

            migrationBuilder.DropTable(
                name: "Fatura");

            migrationBuilder.DropTable(
                name: "Useri");

            migrationBuilder.DropTable(
                name: "BiznesiKonzola");

            migrationBuilder.DropTable(
                name: "VideoLoja");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Konzola");

            migrationBuilder.DropTable(
                name: "Lokali");

            migrationBuilder.DropTable(
                name: "Biznesi");
        }
    }
}
