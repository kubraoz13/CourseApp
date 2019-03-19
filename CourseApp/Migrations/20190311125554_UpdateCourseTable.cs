using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseApp.Migrations
{
    public partial class UpdateCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "Courses",
                nullable: true); //true null gelebilir demek

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            //İnsturctor ve Course birbirine foreign key ile bağlı
            //Restrict: Instructor tablosundaki kayıt Course tablosundada kullanılıyorsa silemezsiniz demek.
            //SetNull: Eğitmen tabosundan kayıt silinirse Course tablosundaki ilişkili alan null kalır.
            //CasCade:Eğitmen tablasundan kayıt silinirse Cours tablosundanda silinir.
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Courses");
        }
    }
}
