using Microsoft.EntityFrameworkCore.Migrations;

namespace MangaStore.Database.Migrations
{
    public partial class AddNullableRequiredFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Genres",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CoverValue",
                table: "Books",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Genres",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<decimal>(
                name: "CoverValue",
                table: "Books",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
