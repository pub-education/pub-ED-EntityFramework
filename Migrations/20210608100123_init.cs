using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Student_id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Teacher_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Teacher_id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Course_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher_id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Teacher_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Course_id);
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_Teacher_id1",
                        column: x => x.Teacher_id1,
                        principalTable: "Teachers",
                        principalColumn: "Teacher_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Assignment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Course_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Assignment_id);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_Course_id1",
                        column: x => x.Course_id1,
                        principalTable: "Courses",
                        principalColumn: "Course_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesCourse_id = table.Column<int>(type: "int", nullable: false),
                    StudentsStudent_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesCourse_id, x.StudentsStudent_id });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_CoursesCourse_id",
                        column: x => x.CoursesCourse_id,
                        principalTable: "Courses",
                        principalColumn: "Course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Students_StudentsStudent_id",
                        column: x => x.StudentsStudent_id,
                        principalTable: "Students",
                        principalColumn: "Student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_Course_id1",
                table: "Assignments",
                column: "Course_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Teacher_id1",
                table: "Courses",
                column: "Teacher_id1");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsStudent_id",
                table: "CourseStudent",
                column: "StudentsStudent_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
