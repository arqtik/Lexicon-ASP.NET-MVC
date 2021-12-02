using Microsoft.EntityFrameworkCore.Migrations;

namespace DevASPMVC.Migrations
{
    public partial class LanguageUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguage_Language_LanguageID",
                table: "PersonLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "Languages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguage_Languages_LanguageID",
                table: "PersonLanguage",
                column: "LanguageID",
                principalTable: "Languages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguage_Languages_LanguageID",
                table: "PersonLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Language");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguage_Language_LanguageID",
                table: "PersonLanguage",
                column: "LanguageID",
                principalTable: "Language",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
