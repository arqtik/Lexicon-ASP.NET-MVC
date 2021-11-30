using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevASPMVC.Migrations
{
    public partial class CountryCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "People",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CountryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "ID", "Name" },
                values: new object[] { -1, "Sweden" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "ID", "CountryID", "Name" },
                values: new object[] { -1, -1, "Stockholm" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "ID", "CountryID", "Name" },
                values: new object[] { -2, -1, "Göteborg" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: -2,
                column: "CityID",
                value: -2);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: -1,
                column: "CityID",
                value: -1);

            migrationBuilder.CreateIndex(
                name: "IX_People_CityID",
                table: "People",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryID",
                table: "City",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_People_City_CityID",
                table: "People",
                column: "CityID",
                principalTable: "City",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_City_CityID",
                table: "People");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_People_CityID",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "People",
                type: "varchar(255) CHARACTER SET utf8mb4",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: -2,
                column: "Address",
                value: "Tidnings gatan 3F 65351 Borås");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "ID",
                keyValue: -1,
                column: "Address",
                value: "Gustav gatan 21C 54412 Gävle");
        }
    }
}
