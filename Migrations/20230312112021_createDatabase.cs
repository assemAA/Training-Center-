using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_Project.Migrations
{
    /// <inheritdoc />
    public partial class createDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    manager = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Instractors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<double>(type: "float", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dept_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instractors", x => x.id);
                    table.ForeignKey(
                        name: "FK_Instractors_Departements_dept_id",
                        column: x => x.dept_id,
                        principalTable: "Departements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    grade = table.Column<double>(type: "float", nullable: false),
                    dept_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.id);
                    table.ForeignKey(
                        name: "FK_Trainees_Departements_dept_id",
                        column: x => x.dept_id,
                        principalTable: "Departements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    degree = table.Column<double>(type: "float", nullable: false),
                    min_degree = table.Column<double>(type: "float", nullable: false),
                    dept_id = table.Column<int>(type: "int", nullable: false),
                    Instractorid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Departements_dept_id",
                        column: x => x.dept_id,
                        principalTable: "Departements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Instractors_Instractorid",
                        column: x => x.Instractorid,
                        principalTable: "Instractors",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CrsResults",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    degree = table.Column<double>(type: "float", nullable: false),
                    crs_id = table.Column<int>(type: "int", nullable: false),
                    trainee_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrsResults", x => x.id);
                    table.ForeignKey(
                        name: "FK_CrsResults_Courses_crs_id",
                        column: x => x.crs_id,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrsResults_Trainees_trainee_id",
                        column: x => x.trainee_id,
                        principalTable: "Trainees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_dept_id",
                table: "Courses",
                column: "dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Instractorid",
                table: "Courses",
                column: "Instractorid");

            migrationBuilder.CreateIndex(
                name: "IX_CrsResults_crs_id",
                table: "CrsResults",
                column: "crs_id");

            migrationBuilder.CreateIndex(
                name: "IX_CrsResults_trainee_id",
                table: "CrsResults",
                column: "trainee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Instractors_dept_id",
                table: "Instractors",
                column: "dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_dept_id",
                table: "Trainees",
                column: "dept_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrsResults");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "Instractors");

            migrationBuilder.DropTable(
                name: "Departements");
        }
    }
}
