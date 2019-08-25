using Microsoft.EntityFrameworkCore.Migrations;

namespace IDE.DAL.Migrations
{
    public partial class editorSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EditorSettings",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EditorProjectSettings",
                table: "Projects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditorSettings",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EditorProjectSettings",
                table: "Projects");
        }
    }
}
