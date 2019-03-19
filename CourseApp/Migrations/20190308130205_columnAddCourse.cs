using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseApp.Migrations
{
    public partial class columnAddCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Courses");
        }
    }
}
