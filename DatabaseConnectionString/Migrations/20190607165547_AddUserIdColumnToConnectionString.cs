using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseConnectionString.Migrations
{
    public partial class AddUserIdColumnToConnectionString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ConnectionStrings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ConnectionStrings");
        }
    }
}
