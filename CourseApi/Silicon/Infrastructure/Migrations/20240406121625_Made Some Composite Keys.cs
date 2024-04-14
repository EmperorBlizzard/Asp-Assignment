using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MadeSomeCompositeKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseIncludes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IncludeText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseIncludes", x => new { x.Id, x.CourseId });
                    table.ForeignKey(
                        name: "FK_CourseIncludes_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseLearns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LearnText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLearns", x => new { x.Id, x.CourseId });
                    table.ForeignKey(
                        name: "FK_CourseLearns_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProgramHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramDetails", x => new { x.Id, x.CourseId });
                    table.ForeignKey(
                        name: "FK_ProgramDetails_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseIncludes_CourseId",
                table: "CourseIncludes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLearns_CourseId",
                table: "CourseLearns",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramDetails_CourseId",
                table: "ProgramDetails",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseIncludes");

            migrationBuilder.DropTable(
                name: "CourseLearns");

            migrationBuilder.DropTable(
                name: "ProgramDetails");
        }
    }
}
