using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Respondent_RespondentId",
                table: "Responses");

            migrationBuilder.DropTable(
                name: "Respondent");

            migrationBuilder.RenameColumn(
                name: "RespondentId",
                table: "Responses",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Responses_RespondentId",
                table: "Responses",
                newName: "IX_Responses_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Users_UserId",
                table: "Responses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Users_UserId",
                table: "Responses");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Responses",
                newName: "RespondentId");

            migrationBuilder.RenameIndex(
                name: "IX_Responses_UserId",
                table: "Responses",
                newName: "IX_Responses_RespondentId");

            migrationBuilder.CreateTable(
                name: "Respondent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respondent", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Respondent_RespondentId",
                table: "Responses",
                column: "RespondentId",
                principalTable: "Respondent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
