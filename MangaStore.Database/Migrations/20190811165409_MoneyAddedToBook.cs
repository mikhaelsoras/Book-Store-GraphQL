using Microsoft.EntityFrameworkCore.Migrations;

namespace MangaStore.Database.Migrations
{
    public partial class MoneyAddedToBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverValue",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "CoverPrice_Currency",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CoverPrice_Value",
                table: "Books",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverPrice_Currency",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CoverPrice_Value",
                table: "Books");

            migrationBuilder.AddColumn<decimal>(
                name: "CoverValue",
                table: "Books",
                nullable: true);
        }
    }
}
