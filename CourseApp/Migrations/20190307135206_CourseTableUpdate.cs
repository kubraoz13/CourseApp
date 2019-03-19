using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseApp.Migrations
{
    public partial class CourseTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(decimal));
        }
    }
}
