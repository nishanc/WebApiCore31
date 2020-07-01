using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCore31.Migrations
{
    public partial class AddedCityToValuesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Values",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Values");
        }
    }
}
