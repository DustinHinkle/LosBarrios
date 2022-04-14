using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp.Data.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    EmployerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployerName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.EmployerId);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Employer = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    CellPhone = table.Column<string>(type: "TEXT", nullable: true),
                    BusinessPhone = table.Column<string>(type: "TEXT", nullable: true),
                    Demonstration = table.Column<string>(type: "TEXT", nullable: true),
                    LunchCount = table.Column<int>(type: "INTEGER", nullable: false),
                    TopicTitle = table.Column<string>(type: "TEXT", nullable: true),
                    TopicDes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerId);
                });

            migrationBuilder.CreateTable(
                name: "SpeakerSessions",
                columns: table => new
                {
                    SpeakerSessionId = table.Column<string>(type: "TEXT", nullable: false),
                    SpeakerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Podium = table.Column<bool>(type: "INTEGER", nullable: false),
                    Outlet = table.Column<bool>(type: "INTEGER", nullable: false),
                    CleanWall = table.Column<bool>(type: "INTEGER", nullable: false),
                    WhiteBoard = table.Column<bool>(type: "INTEGER", nullable: false),
                    DemoTable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakerSessions", x => x.SpeakerSessionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "SpeakerSessions");
        }
    }
}
