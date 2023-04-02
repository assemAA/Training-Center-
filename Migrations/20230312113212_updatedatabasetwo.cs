using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI_Project.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabasetwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instractors_Departements_dept_id",
                table: "Instractors");

            migrationBuilder.AlterColumn<int>(
                name: "dept_id",
                table: "Instractors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Instractors_Departements_dept_id",
                table: "Instractors",
                column: "dept_id",
                principalTable: "Departements",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instractors_Departements_dept_id",
                table: "Instractors");

            migrationBuilder.AlterColumn<int>(
                name: "dept_id",
                table: "Instractors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instractors_Departements_dept_id",
                table: "Instractors",
                column: "dept_id",
                principalTable: "Departements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
