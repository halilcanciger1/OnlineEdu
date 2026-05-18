using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEdu.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_change_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSocial_AspNetUsers_TeacherId",
                table: "TeacherSocial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherSocial",
                table: "TeacherSocial");

            migrationBuilder.RenameTable(
                name: "TeacherSocial",
                newName: "TeachersSocials");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSocial_TeacherId",
                table: "TeachersSocials",
                newName: "IX_TeachersSocials_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeachersSocials",
                table: "TeachersSocials",
                column: "TeacherSocialId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersSocials_AspNetUsers_TeacherId",
                table: "TeachersSocials",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeachersSocials_AspNetUsers_TeacherId",
                table: "TeachersSocials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeachersSocials",
                table: "TeachersSocials");

            migrationBuilder.RenameTable(
                name: "TeachersSocials",
                newName: "TeacherSocial");

            migrationBuilder.RenameIndex(
                name: "IX_TeachersSocials_TeacherId",
                table: "TeacherSocial",
                newName: "IX_TeacherSocial_TeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherSocial",
                table: "TeacherSocial",
                column: "TeacherSocialId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSocial_AspNetUsers_TeacherId",
                table: "TeacherSocial",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
