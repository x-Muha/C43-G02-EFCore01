using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreAssignment01.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedModelsToAcceptNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_course_Insts_Instructors_Inst_Id",
                table: "course_Insts");

            migrationBuilder.DropIndex(
                name: "IX_departments_ManagerId",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "Ins_Id",
                table: "departments");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "HiringDate",
                table: "departments",
                type: "date",
                nullable: true,
                defaultValueSql: "CAST(GETDATE() AS DATE)",
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateIndex(
                name: "IX_departments_ManagerId",
                table: "departments",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_course_Insts_Instructors_Inst_Id",
                table: "course_Insts",
                column: "Inst_Id",
                principalTable: "Instructors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_course_Insts_Instructors_Inst_Id",
                table: "course_Insts");

            migrationBuilder.DropIndex(
                name: "IX_departments_ManagerId",
                table: "departments");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "HiringDate",
                table: "departments",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true,
                oldDefaultValueSql: "CAST(GETDATE() AS DATE)");

            migrationBuilder.AddColumn<int>(
                name: "Ins_Id",
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
                name: "FK_course_Insts_Instructors_Inst_Id",
                table: "course_Insts",
                column: "Inst_Id",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
