using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreAssignment01.Migrations
{
    /// <inheritdoc />
    public partial class AddedLastRS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_departments_ManagerId",
                table: "departments",
                column: "ManagerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_departments_Instructors_ManagerId",
                table: "departments",
                column: "ManagerId",
                principalTable: "Instructors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_Instructors_ManagerId",
                table: "departments");

            migrationBuilder.DropIndex(
                name: "IX_departments_ManagerId",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "departments");
        }
    }
}
