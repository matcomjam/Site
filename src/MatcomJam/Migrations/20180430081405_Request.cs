using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MatcomJam.Migrations
{
    public partial class Request : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Properties",
                table: "OpenIddictTokens",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OpenIddictScopes",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "OpenIddictScopes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Properties",
                table: "OpenIddictScopes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resources",
                table: "OpenIddictScopes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Properties",
                table: "OpenIddictAuthorizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsentType",
                table: "OpenIddictApplications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Permissions",
                table: "OpenIddictApplications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Properties",
                table: "OpenIddictApplications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictScopes_Name",
                table: "OpenIddictScopes",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OpenIddictScopes_Name",
                table: "OpenIddictScopes");

            migrationBuilder.DropColumn(
                name: "Properties",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "OpenIddictScopes");

            migrationBuilder.DropColumn(
                name: "Properties",
                table: "OpenIddictScopes");

            migrationBuilder.DropColumn(
                name: "Resources",
                table: "OpenIddictScopes");

            migrationBuilder.DropColumn(
                name: "Properties",
                table: "OpenIddictAuthorizations");

            migrationBuilder.DropColumn(
                name: "ConsentType",
                table: "OpenIddictApplications");

            migrationBuilder.DropColumn(
                name: "Permissions",
                table: "OpenIddictApplications");

            migrationBuilder.DropColumn(
                name: "Properties",
                table: "OpenIddictApplications");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OpenIddictScopes",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
