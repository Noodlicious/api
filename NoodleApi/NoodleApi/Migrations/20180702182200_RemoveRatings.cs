using Microsoft.EntityFrameworkCore.Migrations;

namespace NoodleApi.Migrations
{
    public partial class RemoveRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Noodles");

            migrationBuilder.DropColumn(
                name: "Ratings",
                table: "Noodles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Likes",
                table: "Noodles",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Ratings",
                table: "Noodles",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
