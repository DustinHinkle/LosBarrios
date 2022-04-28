using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp.Data.Migrations
{
    public partial class anothermigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.RenameColumn(
                name: "SpeakerId",
                table: "SpeakerSessions",
                newName: "SessionTwo");

            migrationBuilder.AddColumn<string>(
                name: "SessionCategory",
                table: "SpeakerSessions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SessionOne",
                table: "SpeakerSessions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SessionSpeakerSpeakerId",
                table: "SpeakerSessions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SignupDate",
                table: "SpeakerSessions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SpeakerFullName",
                table: "SpeakerSessions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpeakerSessions_SessionSpeakerSpeakerId",
                table: "SpeakerSessions",
                column: "SessionSpeakerSpeakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerSessions_Speaker_SessionSpeakerSpeakerId",
                table: "SpeakerSessions",
                column: "SessionSpeakerSpeakerId",
                principalTable: "Speaker",
                principalColumn: "SpeakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerSessions_Speaker_SessionSpeakerSpeakerId",
                table: "SpeakerSessions");

            migrationBuilder.DropIndex(
                name: "IX_SpeakerSessions_SessionSpeakerSpeakerId",
                table: "SpeakerSessions");

            migrationBuilder.DropColumn(
                name: "SessionCategory",
                table: "SpeakerSessions");

            migrationBuilder.DropColumn(
                name: "SessionOne",
                table: "SpeakerSessions");

            migrationBuilder.DropColumn(
                name: "SessionSpeakerSpeakerId",
                table: "SpeakerSessions");

            migrationBuilder.DropColumn(
                name: "SignupDate",
                table: "SpeakerSessions");

            migrationBuilder.DropColumn(
                name: "SpeakerFullName",
                table: "SpeakerSessions");

            migrationBuilder.RenameColumn(
                name: "SessionTwo",
                table: "SpeakerSessions",
                newName: "SpeakerId");

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
