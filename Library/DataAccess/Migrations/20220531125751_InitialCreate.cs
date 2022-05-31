using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KUSYSDemo.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(74)", maxLength: 74, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourseMaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourseMaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseId", "CourseName" },
                values: new object[,]
                {
                    { 1, "CSI101", "Introduction to Computer Science" },
                    { 2, "CSI102", "Algorithms" },
                    { 3, "MAT101", "Calculus" },
                    { 4, "PHY101", "Physics" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "CourseId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 31, 15, 57, 51, 786, DateTimeKind.Local).AddTicks(4217), 0, "Uzay", "KAHRAMAN" },
                    { 2, new DateTime(2022, 5, 31, 15, 57, 51, 786, DateTimeKind.Local).AddTicks(4226), 0, "Yağmur", "KAHRAMAN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "StudentCourseMaps");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
