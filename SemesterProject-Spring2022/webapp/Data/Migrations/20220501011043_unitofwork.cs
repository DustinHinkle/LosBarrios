using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp.Data.Migrations
{
    public partial class unitofwork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.AlterColumn<int>(
                name: "SpeakerSessionId",
                table: "SpeakerSessions",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "SpeakerSessionId",
                table: "Speaker",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_SpeakerSessionId",
                table: "Speaker",
                column: "SpeakerSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_SpeakerSessions_SpeakerSessionId",
                table: "Speaker",
                column: "SpeakerSessionId",
                principalTable: "SpeakerSessions",
                principalColumn: "SpeakerSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_SpeakerSessions_SpeakerSessionId",
                table: "Speaker");

            migrationBuilder.DropIndex(
                name: "IX_Speaker_SpeakerSessionId",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "SpeakerSessionId",
                table: "Speaker");

            migrationBuilder.AlterColumn<string>(
                name: "SpeakerSessionId",
                table: "SpeakerSessions",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

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
        }
    }
}
