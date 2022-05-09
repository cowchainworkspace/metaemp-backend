using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetaEmp.Data.SqlSever.Migrations
{
    public partial class SpecialistReferenceCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Specialists",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialists_CompanyId",
                table: "Specialists",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialists_Companies_CompanyId",
                table: "Specialists",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialists_Companies_CompanyId",
                table: "Specialists");

            migrationBuilder.DropIndex(
                name: "IX_Specialists_CompanyId",
                table: "Specialists");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Specialists");
        }
    }
}
