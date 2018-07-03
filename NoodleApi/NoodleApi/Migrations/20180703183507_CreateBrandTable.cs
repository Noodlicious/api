using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoodleApi.Migrations
{
    public partial class CreateBrandTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Noodles");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Noodles");

            migrationBuilder.AddColumn<long>(
                name: "BrandId",
                table: "Noodles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Noodles_BrandId",
                table: "Noodles",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Noodles_Brands_BrandId",
                table: "Noodles",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noodles_Brands_BrandId",
                table: "Noodles");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Noodles_BrandId",
                table: "Noodles");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Noodles");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Noodles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Noodles",
                nullable: true);
        }
    }
}
