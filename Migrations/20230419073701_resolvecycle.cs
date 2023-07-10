using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIDemoApp.Migrations
{
    /// <inheritdoc />
    public partial class resolvecycle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    StudentCoursesCourseId = table.Column<int>(type: "int", nullable: false),
                    StudentCoursesStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.StudentCoursesCourseId, x.StudentCoursesStudentId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_StudentCoursesCourseId",
                        column: x => x.StudentCoursesCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Students_StudentCoursesStudentId",
                        column: x => x.StudentCoursesStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSubject",
                columns: table => new
                {
                    CourseSubjectsCourseId = table.Column<int>(type: "int", nullable: false),
                    CourseSubjectsSubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSubject", x => new { x.CourseSubjectsCourseId, x.CourseSubjectsSubjectId });
                    table.ForeignKey(
                        name: "FK_CourseSubject_Courses_CourseSubjectsCourseId",
                        column: x => x.CourseSubjectsCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSubject_Subjects_CourseSubjectsSubjectId",
                        column: x => x.CourseSubjectsSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentCoursesStudentId",
                table: "CourseStudent",
                column: "StudentCoursesStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubject_CourseSubjectsSubjectId",
                table: "CourseSubject",
                column: "CourseSubjectsSubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "CourseSubject");
        }
    }
}
