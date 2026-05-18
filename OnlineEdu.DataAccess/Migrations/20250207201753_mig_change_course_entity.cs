using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEdu.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_change_course_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseRegister",
                columns: table => new
                {
                    CourseRegisterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRegister", x => x.CourseRegisterId);
                    table.ForeignKey(
                        name: "FK_CourseRegister_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseRegister_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_AppUserId",
                table: "Course",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegister_AppUserId",
                table: "CourseRegister",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegister_CourseId",
                table: "CourseRegister",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_AppUserId",
                table: "Course",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_AppUserId",
                table: "Course");

            migrationBuilder.DropTable(
                name: "CourseRegister");

            migrationBuilder.DropIndex(
                name: "IX_Course_AppUserId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");
        }
    }
}
