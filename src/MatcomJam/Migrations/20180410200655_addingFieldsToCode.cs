using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MatcomJam.Migrations
{
    public partial class addingFieldsToCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Codes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Codes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Codes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProblemId",
                table: "Codes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Codes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Codes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Codes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Codes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Codes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Codes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Codes_LanguageId",
                table: "Codes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Codes_ProblemId",
                table: "Codes",
                column: "ProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_Codes_UserId1",
                table: "Codes",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Codes_Languages_LanguageId",
                table: "Codes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Codes_Problems_ProblemId",
                table: "Codes",
                column: "ProblemId",
                principalTable: "Problems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Codes_AspNetUsers_UserId1",
                table: "Codes",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Codes_Languages_LanguageId",
                table: "Codes");

            migrationBuilder.DropForeignKey(
                name: "FK_Codes_Problems_ProblemId",
                table: "Codes");

            migrationBuilder.DropForeignKey(
                name: "FK_Codes_AspNetUsers_UserId1",
                table: "Codes");

            migrationBuilder.DropIndex(
                name: "IX_Codes_LanguageId",
                table: "Codes");

            migrationBuilder.DropIndex(
                name: "IX_Codes_ProblemId",
                table: "Codes");

            migrationBuilder.DropIndex(
                name: "IX_Codes_UserId1",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "ProblemId",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Codes");
        }
    }
}
