using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Framework.UTest.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countryEntityRepositories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countryEntityRepositories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "stateRepositories",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stateRepositories", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_stateRepositories_countryEntityRepositories_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countryEntityRepositories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stateRepositories_CountryId",
                table: "stateRepositories",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stateRepositories");

            migrationBuilder.DropTable(
                name: "countryEntityRepositories");
        }
    }
}
