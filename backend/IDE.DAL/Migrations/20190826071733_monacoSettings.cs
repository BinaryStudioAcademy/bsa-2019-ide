using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IDE.DAL.Migrations
{
    public partial class monacoSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EditorSettingsId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EditorProjectSettingsId",
                table: "Projects",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EditorSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LineNumbers = table.Column<string>(nullable: true),
                    RoundedSelection = table.Column<bool>(nullable: false),
                    ScrollBeyondLastLine = table.Column<bool>(nullable: false),
                    ReadOnly = table.Column<bool>(nullable: false),
                    FontSize = table.Column<int>(nullable: false),
                    TabSize = table.Column<int>(nullable: false),
                    CursorStyle = table.Column<string>(nullable: true),
                    LineHeight = table.Column<int>(nullable: false),
                    Theme = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditorSettings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EditorSettingsId",
                table: "Users",
                column: "EditorSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EditorProjectSettingsId",
                table: "Projects",
                column: "EditorProjectSettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_EditorSettings_EditorProjectSettingsId",
                table: "Projects",
                column: "EditorProjectSettingsId",
                principalTable: "EditorSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_EditorSettings_EditorSettingsId",
                table: "Users",
                column: "EditorSettingsId",
                principalTable: "EditorSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_EditorSettings_EditorProjectSettingsId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_EditorSettings_EditorSettingsId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "EditorSettings");

            migrationBuilder.DropIndex(
                name: "IX_Users_EditorSettingsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Projects_EditorProjectSettingsId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EditorSettingsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EditorProjectSettingsId",
                table: "Projects");
        }
    }
}
