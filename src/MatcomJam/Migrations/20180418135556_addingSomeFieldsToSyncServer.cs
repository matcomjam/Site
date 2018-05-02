using Microsoft.EntityFrameworkCore.Migrations;

namespace MatcomJam.Migrations
{
    public partial class addingSomeFieldsToSyncServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URL_Get",
                table: "SyncServers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "URL_Post",
                table: "SyncServers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL_Get",
                table: "SyncServers");

            migrationBuilder.DropColumn(
                name: "URL_Post",
                table: "SyncServers");
        }
    }
}
