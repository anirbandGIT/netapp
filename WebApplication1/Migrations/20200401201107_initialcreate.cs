using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseCategoriesData",
                columns: table => new
                {
                    courseCategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    categoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategoriesData", x => x.courseCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    courseId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    courseName = table.Column<string>(nullable: true),
                    courseDesc = table.Column<string>(nullable: true),
                    courseUrl = table.Column<string>(nullable: true),
                    courseRating = table.Column<string>(nullable: true),
                    courseCreation = table.Column<DateTime>(nullable: false),
                    ccId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.courseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseCategoriesData");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
