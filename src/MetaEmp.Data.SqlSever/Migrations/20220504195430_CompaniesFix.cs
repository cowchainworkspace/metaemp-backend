using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetaEmp.Data.SqlSever.Migrations
{
    public partial class CompaniesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_AppUsers_OwnerId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_File_LogoId",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_File",
                table: "File");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "File",
                newName: "Files");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_Company_OwnerId",
                table: "Companies",
                newName: "IX_Companies_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_LogoId",
                table: "Companies",
                newName: "IX_Companies_LogoId");

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "Files",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AppUsers_OwnerId",
                table: "Companies",
                column: "OwnerId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Files_LogoId",
                table: "Companies",
                column: "LogoId",
                principalTable: "Files",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AppUsers_OwnerId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Files_LogoId",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Files",
                newName: "File");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_OwnerId",
                table: "Company",
                newName: "IX_Company_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_LogoId",
                table: "Company",
                newName: "IX_Company_LogoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_File",
                table: "File",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_AppUsers_OwnerId",
                table: "Company",
                column: "OwnerId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_File_LogoId",
                table: "Company",
                column: "LogoId",
                principalTable: "File",
                principalColumn: "Id");
        }
    }
}
