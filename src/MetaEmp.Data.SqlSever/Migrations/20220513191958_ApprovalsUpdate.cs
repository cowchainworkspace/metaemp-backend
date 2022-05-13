using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetaEmp.Data.SqlSever.Migrations
{
    public partial class ApprovalsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Specialists_SpecialistId",
                table: "Experiences");

            migrationBuilder.DropTable(
                name: "WorkApproval");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpecialistId",
                table: "Experiences",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Experiences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Receiver",
                table: "Experiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RejectedReason",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialistFullname",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Experiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Specialists_SpecialistId",
                table: "Experiences",
                column: "SpecialistId",
                principalTable: "Specialists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Specialists_SpecialistId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Receiver",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "RejectedReason",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "SpecialistFullname",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Experiences");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpecialistId",
                table: "Experiences",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "WorkApproval",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SpecialistId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Receiver = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkApproval", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkApproval_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkApproval_Specialists_SpecialistId",
                        column: x => x.SpecialistId,
                        principalTable: "Specialists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkApproval_CompanyId",
                table: "WorkApproval",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkApproval_SpecialistId",
                table: "WorkApproval",
                column: "SpecialistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Specialists_SpecialistId",
                table: "Experiences",
                column: "SpecialistId",
                principalTable: "Specialists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
