using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseConnectionString.Migrations
{
    public partial class PopulateDataToConnectionStringsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into ConnectionStrings Values ('PX', 'PX Value')");
            migrationBuilder.Sql("Insert Into ConnectionStrings Values ('QA', 'QA Value')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From ConnectionStrings Where EnvironmentName = 'PX'");
            migrationBuilder.Sql("Delete From ConnectionStrings Where EnvironmentName = 'QA'");
        }
    }
}
