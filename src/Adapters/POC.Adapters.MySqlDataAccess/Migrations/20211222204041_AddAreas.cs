using Microsoft.EntityFrameworkCore.Migrations;

namespace POC.Adapters.MySqlDataAccess.Migrations
{
    public partial class AddAreas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EAreas",
                table: "OrderItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EAreas",
                table: "OrderItems");
        }
    }
}
