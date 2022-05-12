using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetaEmp.Data.SqlSever.Migrations
{
    public partial class CompanyProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyOwners_OwnerId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "CompanyOwners");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_OwnerId",
                table: "Companies",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_OwnerId",
                table: "Companies");

            migrationBuilder.CreateTable(
                name: "CompanyOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyOwners_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyOwners_UserId",
                table: "CompanyOwners",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyOwners_OwnerId",
                table: "Companies",
                column: "OwnerId",
                principalTable: "CompanyOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
