using Microsoft.EntityFrameworkCore.Migrations;

namespace MatcomJam.Migrations
{
    public partial class ChangingUserIdType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Codes_AspNetUsers_UserId1",
                table: "Codes");

            migrationBuilder.DropIndex(
                name: "IX_Codes_UserId1",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Codes");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Codes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Codes_UserId",
                table: "Codes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Codes_AspNetUsers_UserId",
                table: "Codes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Codes_AspNetUsers_UserId",
                table: "Codes");

            migrationBuilder.DropIndex(
                name: "IX_Codes_UserId",
                table: "Codes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Codes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Codes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Codes_UserId1",
                table: "Codes",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Codes_AspNetUsers_UserId1",
                table: "Codes",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
