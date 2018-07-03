using Microsoft.EntityFrameworkCore.Migrations;

namespace NoodleApi.Migrations
{
    public partial class Description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Noodles",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Noodles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Noodles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Noodles",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
