using Microsoft.EntityFrameworkCore.Migrations;

namespace MangaStore.Database.Migrations
{
    public partial class MoneyDecimalNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CoverPrice_Value",
                table: "Books",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CoverPrice_Value",
                table: "Books",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
