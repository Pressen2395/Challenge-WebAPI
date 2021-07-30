using Microsoft.EntityFrameworkCore.Migrations;

namespace challenge.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "challenges",
                columns: table => new
                {
                    challengeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_challenges", x => x.challengeId);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    playerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    playerName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    solution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    result = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.playerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "challenges");

            migrationBuilder.DropTable(
                name: "players");
        }
    }
}
