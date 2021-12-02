using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevASPMVC.Migrations
{
    public partial class CountriesAndCities : Migration
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
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CountryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "ID", "Name" },
                values: new object[] { -1, "Sweden" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CountryID", "Name" },
                values: new object[] { -1, -1, "Stockholm" });

            migrationBuilder.InsertData(
                table: "Cities",
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
                name: "IX_Cities_CountryID",
                table: "Cities",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityID",
                table: "People",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityID",
                table: "People");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

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
