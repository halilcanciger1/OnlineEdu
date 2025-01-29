using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEdu.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_change_courseCategoryId_prop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Course_CourseId1",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_CourseId1",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "Course");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseCategoryId",
                table: "Course",
                column: "CourseCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_CourseCategories_CourseCategoryId",
                table: "Course",
                column: "CourseCategoryId",
                principalTable: "CourseCategories",
                principalColumn: "CourseCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_CourseCategories_CourseCategoryId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_CourseCategoryId",
                table: "Course");

            migrationBuilder.AddColumn<int>(
                name: "CourseId1",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseId1",
                table: "Course",
                column: "CourseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Course_CourseId1",
                table: "Course",
                column: "CourseId1",
                principalTable: "Course",
                principalColumn: "CourseId");
        }
    }
}
