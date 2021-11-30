using Microsoft.EntityFrameworkCore.Migrations;

namespace DevASPMVC.Migrations
{
    public partial class PersonSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "Address", "Email", "FirstName", "Gender", "LastName" },
                values: new object[] { -1, "Gustav gatan 21C 54412 Gävle", "johhug@domain.com", "Johannes", 0, "Hugosson" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "Address", "Email", "FirstName", "Gender", "LastName" },
                values: new object[] { -2, "Tidnings gatan 3F 65351 Borås", "ingand@domain.com", "Ingrid", 1, "Andersson" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "ID",
                keyValue: -1);
        }
    }
}
