using Microsoft.EntityFrameworkCore.Migrations;

namespace ITToolTest.Migrations
{
    public partial class AddedImgToCoursesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "CoursesData",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "CoursesData");
        }
    }
}
