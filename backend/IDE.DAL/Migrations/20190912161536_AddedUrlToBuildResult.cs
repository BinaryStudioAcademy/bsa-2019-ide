using Microsoft.EntityFrameworkCore.Migrations;

namespace IDE.DAL.Migrations
{
    public partial class AddedUrlToBuildResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UriForArtifactsDownload",
                table: "Builds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UriForArtifactsDownload",
                table: "Builds");
        }
    }
}
