using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetaEmp.Data.SqlSever.Migrations
{
    public partial class DbFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesProfile");

            migrationBuilder.DropColumn(
                name: "SpecialistId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "CourseProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoadsJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProfiles_Files_LogoId",
                        column: x => x.LogoId,
                        principalTable: "Files",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseProfiles_LogoId",
                table: "CourseProfiles",
                column: "LogoId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProfiles_UserId",
                table: "CourseProfiles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseProfiles");

            migrationBuilder.AddColumn<Guid>(
                name: "SpecialistId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CoursesProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoadsJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursesProfile_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesProfile_Files_LogoId",
                        column: x => x.LogoId,
                        principalTable: "Files",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesProfile_LogoId",
                table: "CoursesProfile",
                column: "LogoId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesProfile_UserId",
                table: "CoursesProfile",
                column: "UserId");
        }
    }
}
