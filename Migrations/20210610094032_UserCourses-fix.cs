using Microsoft.EntityFrameworkCore.Migrations;

namespace ITToolTest.Migrations
{
    public partial class UserCoursesfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourse_Courses_CoursesId",
                table: "UserCourse");

            migrationBuilder.AlterColumn<int>(
                name: "CoursesId",
                table: "UserCourse",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourse_Courses_CoursesId",
                table: "UserCourse",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourse_Courses_CoursesId",
                table: "UserCourse");

            migrationBuilder.AlterColumn<int>(
                name: "CoursesId",
                table: "UserCourse",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourse_Courses_CoursesId",
                table: "UserCourse",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
