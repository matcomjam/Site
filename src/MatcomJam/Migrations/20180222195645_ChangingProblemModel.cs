using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QuickApp.Migrations
{
    public partial class ChangingProblemModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_Restriction_RestrictionId",
                table: "Problems");

            migrationBuilder.DropTable(
                name: "Restriction");

            migrationBuilder.DropIndex(
                name: "IX_Problems_RestrictionId",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "RestrictionId",
                table: "Problems");

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Solutions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaximumMessages",
                table: "Problems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MemoryLimit",
                table: "Problems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfNodes",
                table: "Problems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeOfMessages",
                table: "Problems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeLimit",
                table: "Problems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Problems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "Solutions");

            migrationBuilder.DropColumn(
                name: "MaximumMessages",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "MemoryLimit",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "NumberOfNodes",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "SizeOfMessages",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "TimeLimit",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Problems");

            migrationBuilder.AddColumn<int>(
                name: "RestrictionId",
                table: "Problems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Restriction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaximumMessages = table.Column<int>(nullable: false),
                    MemoryLimit = table.Column<int>(nullable: false),
                    NumberOfNodes = table.Column<int>(nullable: false),
                    SizeOfMessages = table.Column<int>(nullable: false),
                    TimeLimit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restriction", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Problems_RestrictionId",
                table: "Problems",
                column: "RestrictionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_Restriction_RestrictionId",
                table: "Problems",
                column: "RestrictionId",
                principalTable: "Restriction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
