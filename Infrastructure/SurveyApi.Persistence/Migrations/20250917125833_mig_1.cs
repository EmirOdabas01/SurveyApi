using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurveyStats",
                table: "SurveyStatuses");

            migrationBuilder.AddColumn<string>(
                name: "SurveyStatuse",
                table: "SurveyStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Visibility",
                table: "Surveys",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "QuestionTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: new Guid("6d7f3e28-1b9c-42a1-8f4a-5c3d7e2f1b66"),
                column: "Type",
                value: "Dropdown");

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: new Guid("a92f1c3d-73b4-40f1-9c88-1e6d5f2c9a11"),
                column: "Type",
                value: "Open");

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: new Guid("b19d5a3c-8c71-4e4f-9d0b-7f13a2e9c8d4"),
                column: "Type",
                value: "Logical");

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: new Guid("f81c7d5a-2e4b-4a9f-97c1-6a2f3e8d9b44"),
                column: "Type",
                value: "Multiple Choise");

            migrationBuilder.UpdateData(
                table: "SurveyStatuses",
                keyColumn: "Id",
                keyValue: new Guid("3b8a4c1b-7f5a-45f3-8cf3-1c6f9e4b9f11"),
                column: "SurveyStatuse",
                value: "Open");

            migrationBuilder.UpdateData(
                table: "SurveyStatuses",
                keyColumn: "Id",
                keyValue: new Guid("4c2e9d17-5f88-4a7e-a62e-2a4f0e9d3f72"),
                column: "SurveyStatuse",
                value: "Closed");

            migrationBuilder.UpdateData(
                table: "SurveyStatuses",
                keyColumn: "Id",
                keyValue: new Guid("e7d9f8a2-24b1-4e73-9c6d-0e2b3f6a9a55"),
                column: "SurveyStatuse",
                value: "Planned");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurveyStatuse",
                table: "SurveyStatuses");

            migrationBuilder.AddColumn<int>(
                name: "SurveyStats",
                table: "SurveyStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Visibility",
                table: "Surveys",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "QuestionTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: new Guid("6d7f3e28-1b9c-42a1-8f4a-5c3d7e2f1b66"),
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: new Guid("a92f1c3d-73b4-40f1-9c88-1e6d5f2c9a11"),
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: new Guid("b19d5a3c-8c71-4e4f-9d0b-7f13a2e9c8d4"),
                column: "Type",
                value: 3);

            migrationBuilder.UpdateData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: new Guid("f81c7d5a-2e4b-4a9f-97c1-6a2f3e8d9b44"),
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SurveyStatuses",
                keyColumn: "Id",
                keyValue: new Guid("3b8a4c1b-7f5a-45f3-8cf3-1c6f9e4b9f11"),
                column: "SurveyStats",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SurveyStatuses",
                keyColumn: "Id",
                keyValue: new Guid("4c2e9d17-5f88-4a7e-a62e-2a4f0e9d3f72"),
                column: "SurveyStats",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SurveyStatuses",
                keyColumn: "Id",
                keyValue: new Guid("e7d9f8a2-24b1-4e73-9c6d-0e2b3f6a9a55"),
                column: "SurveyStats",
                value: 0);
        }
    }
}
