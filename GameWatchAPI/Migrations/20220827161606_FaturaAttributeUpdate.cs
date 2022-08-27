using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameWatchAPI.Migrations
{
    public partial class FaturaAttributeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<bool>(
                name: "Closed",
                table: "Fatura",
                type: "bit",
                nullable: false,
                defaultValueSql: "('FALSE')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Lokali_LokaliID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Closed",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "Oret",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "Statusi",
                table: "BiznesiKonzola");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Useri");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_RoleName",
                table: "Useri",
                newName: "IX_Useri_RoleName");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_LokaliID",
                table: "Useri",
                newName: "IX_Useri_LokaliID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_BiznesiID",
                table: "Useri",
                newName: "IX_Useri_BiznesiID");

            migrationBuilder.AddColumn<string>(
                name: "DateCreated",
                table: "Fatura",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__Useri__LokaliID__4316F928",
                table: "Useri",
                column: "LokaliID",
                principalTable: "Lokali",
                principalColumn: "ID");
        }
    }
}
