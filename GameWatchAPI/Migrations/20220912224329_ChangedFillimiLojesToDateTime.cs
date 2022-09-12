using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameWatchAPI.Migrations
{
    public partial class ChangedFillimiLojesToDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<DateTime>(
                name: "FillimiLojes",
                table: "Fatura",
                type: "datetime2",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<decimal>(
                name: "CmimiTotal",
                table: "Fatura",
                type: "decimal(4,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<string>(
                name: "FillimiLojes",
                table: "Fatura",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<decimal>(
                name: "CmimiTotal",
                table: "Fatura",
                type: "decimal(4,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)",
                oldNullable: true);
        }
    }
}
